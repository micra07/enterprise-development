using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirCompany.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "aircraft_families",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                manufacturer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_aircraft_families", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "passengers",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                passport_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                full_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                birth_date = table.Column<DateOnly>(type: "date", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_passengers", x => x.id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "aircraft_models",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                flight_range = table.Column<double>(type: "double", nullable: false),
                passenger_capacity = table.Column<int>(type: "int", nullable: false),
                cargo_capacity = table.Column<double>(type: "double", nullable: false),
                aircraft_family_id = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_aircraft_models", x => x.id);
                table.ForeignKey(
                    name: "FK_aircraft_models_aircraft_families_aircraft_family_id",
                    column: x => x.aircraft_family_id,
                    principalTable: "aircraft_families",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "flights",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                departure_airport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                arrival_airport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                departure_datetime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                arrival_datetime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                duration = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                aircraft_model_id = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_flights", x => x.id);
                table.ForeignKey(
                    name: "FK_flights_aircraft_models_aircraft_model_id",
                    column: x => x.aircraft_model_id,
                    principalTable: "aircraft_models",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "tickets",
            columns: table => new
            {
                id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                seat_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                has_hand_luggage = table.Column<bool>(type: "tinyint(1)", nullable: true),
                baggage_weight = table.Column<double>(type: "double", nullable: true),
                flight_id = table.Column<int>(type: "int", nullable: false),
                passenger_id = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_tickets", x => x.id);
                table.ForeignKey(
                    name: "FK_tickets_flights_flight_id",
                    column: x => x.flight_id,
                    principalTable: "flights",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_tickets_passengers_passenger_id",
                    column: x => x.passenger_id,
                    principalTable: "passengers",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.InsertData(
            table: "aircraft_families",
            columns: new[] { "id", "manufacturer", "name" },
            values: new object[,]
            {
                { 1, "Airbus", "Family-1" },
                { 2, "Boeing", "Family-2" },
                { 3, "Embraer", "Family-3" },
                { 4, "Bombardier", "Family-4" },
                { 5, "Airbus", "Family-5" },
                { 6, "Airbus", "Family-6" },
                { 7, "Boeing", "Family-7" },
                { 8, "Boeing", "Family-8" },
                { 9, "Embraer", "Family-9" },
                { 10, "Airbus", "Family-10" }
            });

        migrationBuilder.InsertData(
            table: "passengers",
            columns: new[] { "id", "birth_date", "full_name", "passport_number" },
            values: new object[,]
            {
                { 1, new DateOnly(1985, 1, 10), "Ivanov Ivan Ivanovich", "P000001" },
                { 2, new DateOnly(1990, 2, 20), "Petrov Petr Petrovich", "P000002" },
                { 3, new DateOnly(1988, 3, 15), "Sidorov Sidor Sidorovich", "P000003" },
                { 4, new DateOnly(1992, 4, 5), "Kuznetsov Alexey Alexeevich", "P000004" },
                { 5, new DateOnly(1995, 5, 25), "Smirnova Anna Sergeevna", "P000005" },
                { 6, new DateOnly(1987, 6, 18), "Volkov Dmitry Ivanovich", "P000006" },
                { 7, new DateOnly(1991, 7, 30), "Lebedev Sergey Nikolaevich", "P000007" },
                { 8, new DateOnly(1993, 8, 12), "Morozova Elena Vladimirovna", "P000008" },
                { 9, new DateOnly(1989, 9, 9), "Nikolaev Nikolay Ivanovich", "P000009" },
                { 10, new DateOnly(1994, 10, 2), "Fedorova Olga Petrovna", "P000010" },
                { 11, new DateOnly(1984, 11, 11), "Orlov Maxim Viktorovich", "P000011" },
                { 12, new DateOnly(1996, 12, 12), "Sorokina Marina Igorevna", "P000012" },
                { 13, new DateOnly(1986, 6, 6), "Gusev Roman Dmitrievich", "P000013" },
                { 14, new DateOnly(1992, 9, 1), "Markova Irina Sergeevna", "P000014" },
                { 15, new DateOnly(1983, 3, 3), "Nikiforov Alexey Pavlovich", "P000015" },
                { 16, new DateOnly(1990, 4, 4), "Belov Dmitry Sergeevich", "P000016" },
                { 17, new DateOnly(1988, 8, 8), "Karpova Olga Ivanovna", "P000017" },
                { 18, new DateOnly(1991, 1, 1), "Rozov Pavel Anatolievich", "P000018" },
                { 19, new DateOnly(1997, 7, 7), "Simonova Vera Nikolaevna", "P000019" },
                { 20, new DateOnly(1982, 2, 2), "Antonov Ilya Sergeevich", "P000020" }
            });

        migrationBuilder.InsertData(
            table: "aircraft_models",
            columns: new[] { "id", "aircraft_family_id", "cargo_capacity", "flight_range", "name", "passenger_capacity" },
            values: new object[,]
            {
                { 1, 1, 5000.0, 6100.0, "A320-200", 180 },
                { 2, 2, 4800.0, 5600.0, "B737-800", 160 },
                { 3, 3, 2500.0, 4500.0, "E190", 100 },
                { 4, 4, 2000.0, 3700.0, "CRJ900", 90 },
                { 5, 5, 12000.0, 11000.0, "A330-300", 300 },
                { 6, 6, 5200.0, 7400.0, "A321neo", 200 },
                { 7, 7, 14000.0, 13620.0, "B787-8", 242 },
                { 8, 8, 4900.0, 5800.0, "B737-900", 175 },
                { 9, 9, 2600.0, 4800.0, "E195-E2", 120 },
                { 10, 10, 15000.0, 15000.0, "A350-900", 320 }
            });

        migrationBuilder.InsertData(
            table: "flights",
            columns: new[] { "id", "aircraft_model_id", "arrival_airport", "arrival_datetime", "code", "departure_airport", "departure_datetime", "duration" },
            values: new object[,]
            {
                { 1, 1, "London", new DateTime(2025, 10, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), "SU101", "Moscow", new DateTime(2025, 10, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 30, 0, 0) },
                { 2, 2, "Paris", new DateTime(2025, 10, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), "SU102", "Moscow", new DateTime(2025, 10, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0) },
                { 3, 3, "Berlin", new DateTime(2025, 10, 26, 8, 30, 0, 0, DateTimeKind.Unspecified), "SU103", "Saint Petersburg", new DateTime(2025, 10, 26, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 30, 0, 0) },
                { 4, 5, "New York", new DateTime(2025, 10, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), "SU104", "Moscow", new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0) },
                { 5, 5, "Tokyo", new DateTime(2025, 10, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), "SU105", "Moscow", new DateTime(2025, 10, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0) },
                { 6, 4, "Paris", new DateTime(2025, 10, 24, 7, 30, 0, 0, DateTimeKind.Unspecified), "SU106", "Berlin", new DateTime(2025, 10, 24, 6, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 30, 0, 0) },
                { 7, 2, "Dubai", new DateTime(2025, 10, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), "SU107", "Moscow", new DateTime(2025, 10, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0) },
                { 8, 1, "London", new DateTime(2025, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "SU108", "Saint Petersburg", new DateTime(2025, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 30, 0, 0) },
                { 9, 3, "Berlin", new DateTime(2025, 10, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), "SU109", "Moscow", new DateTime(2025, 10, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 30, 0, 0) },
                { 10, 10, "Moscow", new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "SU110", "Paris", new DateTime(2025, 11, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0) }
            });

        migrationBuilder.InsertData(
            table: "tickets",
            columns: new[] { "id", "baggage_weight", "flight_id", "has_hand_luggage", "passenger_id", "seat_number" },
            values: new object[,]
            {
                { 1, 0.0, 1, true, 1, "1A" },
                { 2, 12.0, 1, false, 2, "1B" },
                { 3, 8.0, 1, true, 3, "1C" },
                { 4, 0.0, 1, true, 4, "1D" },
                { 5, 15.0, 1, false, 5, "1E" },
                { 6, 10.0, 1, true, 6, "1F" },
                { 7, 0.0, 1, false, 7, "1G" },
                { 8, 9.0, 1, true, 8, "1H" },
                { 9, 0.0, 2, true, 9, "2A" },
                { 10, 11.0, 2, false, 10, "2B" },
                { 11, 7.0, 2, true, 11, "2C" },
                { 12, 0.0, 2, false, 12, "2D" },
                { 13, 14.0, 2, true, 13, "2E" },
                { 14, 6.0, 2, true, 14, "2F" },
                { 15, 0.0, 2, false, 15, "2G" },
                { 16, 5.0, 3, true, 16, "3A" },
                { 17, 0.0, 3, false, 17, "3B" },
                { 18, 13.0, 3, true, 18, "3C" },
                { 19, 0.0, 3, true, 19, "3D" },
                { 20, 8.0, 3, false, 20, "3E" },
                { 21, 10.0, 3, true, 1, "3F" },
                { 22, 0.0, 4, true, 2, "4A" },
                { 23, 20.0, 4, false, 3, "4B" },
                { 24, 7.0, 4, true, 4, "4C" },
                { 25, 0.0, 4, false, 5, "4D" },
                { 26, 18.0, 4, true, 6, "4E" },
                { 27, 0.0, 5, false, 7, "5A" },
                { 28, 9.0, 5, true, 8, "5B" },
                { 29, 12.0, 5, true, 9, "5C" },
                { 30, 6.0, 5, false, 10, "5D" },
                { 31, 0.0, 6, true, 11, "6A" },
                { 32, 11.0, 6, false, 12, "6B" },
                { 33, 14.0, 6, true, 13, "6C" },
                { 34, 0.0, 7, false, 14, "7A" },
                { 35, 10.0, 7, true, 15, "7B" },
                { 36, 7.0, 8, true, 16, "8A" },
                { 37, 0.0, 8, false, 17, "8B" },
                { 38, 8.0, 9, true, 18, "9A" },
                { 39, 0.0, 9, false, 19, "9B" },
                { 40, 16.0, 10, true, 20, "10A" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_aircraft_models_aircraft_family_id",
            table: "aircraft_models",
            column: "aircraft_family_id");

        migrationBuilder.CreateIndex(
            name: "IX_flights_aircraft_model_id",
            table: "flights",
            column: "aircraft_model_id");

        migrationBuilder.CreateIndex(
            name: "IX_tickets_flight_id",
            table: "tickets",
            column: "flight_id");

        migrationBuilder.CreateIndex(
            name: "IX_tickets_passenger_id",
            table: "tickets",
            column: "passenger_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "tickets");

        migrationBuilder.DropTable(
            name: "flights");

        migrationBuilder.DropTable(
            name: "passengers");

        migrationBuilder.DropTable(
            name: "aircraft_models");

        migrationBuilder.DropTable(
            name: "aircraft_families");
    }
}
