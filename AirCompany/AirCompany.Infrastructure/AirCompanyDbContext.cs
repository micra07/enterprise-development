using AirCompany.Domain.Data;
using AirCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure;

/// <summary>
/// Контекст базы данных авиакомпании, определяющий DbSet-сущности и правила их конфигурации
/// Используется для работы с данными через Entity Framework Core
/// </summary>
public class AirCompanyDbContext(DbContextOptions<AirCompanyDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Таблица семейств самолетов — хранит общие группы моделей одного производителя
    /// </summary>
    public DbSet<AircraftFamily> AircraftFamilies { get; set; }

    /// <summary>
    /// Таблица моделей самолетов - содержит технические характеристики и принадлежность к семействам
    /// </summary>
    public DbSet<AircraftModel> AircraftModels { get; set; }

    /// <summary>
    /// Таблица пассажиров - включает информацию о клиентах авиакомпании
    /// </summary>
    public DbSet<Passenger> Passengers { get; set; }

    /// <summary>
    /// Таблица авиарейсов — хранит сведения о полетах, маршрутах и связанных моделях самолетов
    /// </summary>
    public DbSet<Flight> Flights { get; set; }

    /// <summary>
    /// Таблица билетов — связывает пассажиров с конкретными рейсами и содержит данные о багаже
    /// </summary>
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AircraftFamily>(builder =>
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(f => f.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasMany(f => f.Models)
                    .WithOne(m => m.AircraftFamily)
                    .HasForeignKey(m => m.AircraftFamilyId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(DataSeeder.AircraftFamilies);
        });

        modelBuilder.Entity<AircraftModel>(builder =>
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(m => m.FlightRange)
               .IsRequired();
            builder.Property(m => m.PassengerCapacity)
                .IsRequired();
            builder.Property(m => m.CargoCapacity)
                .IsRequired();

            builder.Property(m => m.AircraftFamilyId)
                .IsRequired();

            builder.HasMany(m => m.Flights)
                    .WithOne(f => f.AircraftModel)
                    .HasForeignKey(f => f.AircraftModelId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(DataSeeder.AircraftModels);
        });

        modelBuilder.Entity<Passenger>(builder =>
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PassportNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(p => p.Tickets)
               .WithOne(t => t.Passenger)
               .HasForeignKey(t => t.PassengerId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(DataSeeder.Passengers);
        });

        modelBuilder.Entity<Flight>(builder =>
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Code)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(f => f.DepartureAirport)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(f => f.ArrivalAirport)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.AircraftModelId)
                .IsRequired();

            builder.HasMany(f => f.Tickets)
               .WithOne(t => t.Flight)
               .HasForeignKey(t => t.FlightId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(DataSeeder.Flights);
        });

        modelBuilder.Entity<Ticket>(builder =>
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.SeatNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(t => t.FlightId)
                .IsRequired();
            builder.Property(t => t.PassengerId)
                .IsRequired();

            builder.HasData(DataSeeder.Tickets);
        });
    }
}