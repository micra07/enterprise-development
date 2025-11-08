var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AirCompany_Api_Host>("aircompany-api-host");

builder.Build().Run();
