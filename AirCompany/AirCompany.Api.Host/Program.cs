using AirCompany.Application.Contracts.Dtos.AircraftFamilies;
using AirCompany.Application.Contracts.Dtos.AircraftModels;
using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Dtos.Passengers;
using AirCompany.Application.Contracts.Dtos.Tickets;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Application.Mapper;
using AirCompany.Application.Services;
using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using AirCompany.Infrastructure;
using AirCompany.Infrastructure.Nats;
using AirCompany.Infrastructure.Nats.Options;
using AirCompany.Infrastructure.Repositories;
using AirCompany.ServiceDefaults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<NatsOptions>()
    .Bind(builder.Configuration.GetSection(NatsOptions.SectionName))
    .Validate(o => !string.IsNullOrWhiteSpace(o.StreamName), "Nats:StreamName is required")
    .Validate(o => !string.IsNullOrWhiteSpace(o.SubjectName), "Nats:SubjectName is required")
    .ValidateOnStart();

builder.AddServiceDefaults();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AirCompanyMapProfile());
});

builder.Services.AddTransient<IRepository<AircraftFamily, int>, AircraftFamilyRepository>();
builder.Services.AddTransient<IRepository<AircraftModel, int>, AircraftModelRepository>();
builder.Services.AddTransient<IRepository<Flight, int>, FlightRepository>();
builder.Services.AddTransient<IRepository<Passenger, int>, PassengerRepository>();
builder.Services.AddTransient<IRepository<Ticket, int>, TicketRepository>();

builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>, AircraftFamilyService>();
builder.Services.AddScoped<IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int>, AircraftModelService>();
builder.Services.AddScoped<IApplicationService<FlightDto, FlightCreateUpdateDto, int>, FlightService>();
builder.Services.AddScoped<IApplicationService<PassengerDto, PassengerCreateUpdateDto, int>, PassengerService>();
builder.Services.AddScoped<IApplicationService<TicketDto, TicketCreateUpdateDto, int>, TicketService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => a.GetName().Name!.StartsWith("AirCompany"))
        .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddHostedService<AirCompanyNatsConsumer>();
builder.AddNatsClient("aircompany-nats");

builder.AddMySqlDbContext<AirCompanyDbContext>(connectionName: "AirCompanyDatabase");

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AirCompanyDbContext>();
    db.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
