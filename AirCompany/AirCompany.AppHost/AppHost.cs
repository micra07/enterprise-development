var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder.AddMySql("mysql-aircompany")
    .AddDatabase("AirCompanyDb");

builder.AddProject<Projects.AirCompany_Api_Host>("api")
    .WithReference(mysql, "AirCompanyDatabase")
    .WaitFor(mysql);

builder.Build().Run();