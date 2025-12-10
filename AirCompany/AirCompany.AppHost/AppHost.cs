var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql-aircompany")
    .AddDatabase("AirCompanyDb");

var natsUserName = builder.AddParameter("NatsLogin");
var natsPassword = builder.AddParameter("NatsPassword");
var nats = builder.AddNats("aircompany-nats", userName: natsUserName, password: natsPassword, port: 4222)
    .WithJetStream()
    .WithArgs("-m", "8222")
    .WithHttpEndpoint(port: 8222, targetPort: 8222);

builder.AddContainer("aircompany-nui", "ghcr.io/nats-nui/nui")
    .WithReference(nats)
    .WaitFor(nats)
    .WithHttpEndpoint(port: 31311, targetPort: 31311);

var natsStream = builder.AddParameter("NatsStream");
var natsSubject = builder.AddParameter("NatsSubject");

builder.AddProject<Projects.AirCompany_Api_Host>("api")
    .WithReference(mysql, "AirCompanyDatabase")
    .WaitFor(mysql)
    .WithEnvironment("Nats:StreamName", natsStream)
    .WithEnvironment("Nats:SubjectName", natsSubject)
    .WithReference(nats)
    .WaitFor(nats);


builder.Build().Run();