using AirCompany.Domain.Models;

namespace AirCompany.Domain.Data;

/// <summary>
/// Класс для заполнения тестового датасета авиакомпании, содержит списки всех сущностей доменной модели и методы для их инициализации
/// </summary>
public class DataSeeder
{
    /// <summary>
    /// Список семейств самолетов
    /// </summary>
    public List<AircraftFamily> AircraftFamilies { get; private set; } = 
    [
        new AircraftFamily { Id = 1,  Name = "Family-1",  Manufacturer = "Airbus" },
        new AircraftFamily { Id = 2,  Name = "Family-2",  Manufacturer = "Boeing" },
        new AircraftFamily { Id = 3,  Name = "Family-3",  Manufacturer = "Embraer" },
        new AircraftFamily { Id = 4,  Name = "Family-4",  Manufacturer = "Bombardier" },
        new AircraftFamily { Id = 5,  Name = "Family-5",  Manufacturer = "Airbus" },
        new AircraftFamily { Id = 6,  Name = "Family-6",  Manufacturer = "Airbus" },
        new AircraftFamily { Id = 7,  Name = "Family-7",  Manufacturer = "Boeing" },
        new AircraftFamily { Id = 8,  Name = "Family-8",  Manufacturer = "Boeing" },
        new AircraftFamily { Id = 9,  Name = "Family-9",  Manufacturer = "Embraer" },
        new AircraftFamily { Id = 10, Name = "Family-10", Manufacturer = "Airbus" }
    ];

    /// <summary>
    /// Список моделей самолетов
    /// </summary>
    public List<AircraftModel> AircraftModels { get; private set; } = 
    [
        new AircraftModel 
        {
            Id = 1,
            Name = "A320-200",
            FlightRange = 6100,
            PassengerCapacity = 180,
            CargoCapacity = 5000,
            AircraftFamilyId = 1
        },
        new AircraftModel 
        {
            Id = 2,
            Name = "B737-800",
            FlightRange = 5600,
            PassengerCapacity = 160,
            CargoCapacity = 4800,
            AircraftFamilyId = 2
        },
        new AircraftModel 
        {
            Id = 3,
            Name = "E190",
            FlightRange = 4500,
            PassengerCapacity = 100,
            CargoCapacity = 2500,
            AircraftFamilyId = 3
        },
        new AircraftModel 
        {
            Id = 4,
            Name = "CRJ900",
            FlightRange = 3700,
            PassengerCapacity = 90,
            CargoCapacity = 2000,
            AircraftFamilyId = 4
        },
        new AircraftModel 
        {
            Id = 5,
            Name = "A330-300",
            FlightRange = 11000,
            PassengerCapacity = 300,
            CargoCapacity = 12000,
            AircraftFamilyId = 5
        },
        new AircraftModel 
        {
            Id = 6,
            Name = "A321neo",
            FlightRange = 7400,
            PassengerCapacity = 200,
            CargoCapacity = 5200,
            AircraftFamilyId = 6
        },
        new AircraftModel 
        {
            Id = 7,
            Name = "B787-8",
            FlightRange = 13620,
            PassengerCapacity = 242,
            CargoCapacity = 14000,
            AircraftFamilyId = 7
        },
        new AircraftModel 
        {
            Id = 8,
            Name = "B737-900",
            FlightRange = 5800,
            PassengerCapacity = 175,
            CargoCapacity = 4900,
            AircraftFamilyId = 8
        },
        new AircraftModel 
        {
            Id = 9,
            Name = "E195-E2",
            FlightRange = 4800,
            PassengerCapacity = 120,
            CargoCapacity = 2600,
            AircraftFamilyId = 9
        },
        new AircraftModel 
        {
            Id = 10,
            Name = "A350-900",
            FlightRange = 15000,
            PassengerCapacity = 320,
            CargoCapacity = 15000,
            AircraftFamilyId = 10
        }
    ];

    /// <summary>
    /// Список авиарейсов
    /// </summary>
    public List<Flight> Flights { get; private set; } = 
    [
        new Flight 
        {
            Id = 1,
            Code = "SU101",
            DepartureAirport = "Moscow",
            ArrivalAirport = "London",
            DepartureDate = new DateTime(2025,10,24,08,00,00),
            ArrivalDate = new DateTime(2025,10,24,10,30,00),
            Duration = TimeSpan.FromHours(2.5),
            AircraftModelId = 1
        },
        new Flight 
        {
            Id = 2,
            Code = "SU102",
            DepartureAirport = "Moscow",
            ArrivalAirport = "Paris",
            DepartureDate = new DateTime(2025,10,25,09,00,00),
            ArrivalDate = new DateTime(2025,10,25,11,00,00),
            Duration = TimeSpan.FromHours(2),
            AircraftModelId = 2
        },
        new Flight 
        {
            Id = 3,
            Code = "SU103",
            DepartureAirport = "Saint Petersburg",
            ArrivalAirport = "Berlin",
            DepartureDate = new DateTime(2025,10,26,07,00,00),
            ArrivalDate = new DateTime(2025,10,26,08,30,00),
            Duration = TimeSpan.FromHours(1.5),
            AircraftModelId = 3
        },
        new Flight 
        {
            Id = 4,
            Code = "SU104",
            DepartureAirport = "Moscow",
            ArrivalAirport = "New York",
            DepartureDate = new DateTime(2025,10,27,12,00,00),
            ArrivalDate = new DateTime(2025,10,27,20,00,00),
            Duration = TimeSpan.FromHours(8),
            AircraftModelId = 5
        },
        new Flight 
        {
            Id = 5,
            Code = "SU105",
            DepartureAirport = "Moscow",
            ArrivalAirport = "Tokyo",
            DepartureDate = new DateTime(2025,10,28,10,00,00),
            ArrivalDate = new DateTime(2025,10,28,20,00,00),
            Duration = TimeSpan.FromHours(10),
            AircraftModelId = 5
        },
        new Flight 
        {
            Id = 6,
            Code = "SU106",
            DepartureAirport = "Berlin",
            ArrivalAirport = "Paris",
            DepartureDate = new DateTime(2025,10,24,06,00,00),
            ArrivalDate = new DateTime(2025,10,24,07,30,00),
            Duration = TimeSpan.FromHours(1.5),
            AircraftModelId = 4
        },
        new Flight 
        {
            Id = 7,
            Code = "SU107",
            DepartureAirport = "Moscow",
            ArrivalAirport = "Dubai",
            DepartureDate = new DateTime(2025,10,29,15,00,00),
            ArrivalDate = new DateTime(2025,10,29,21,00,00),
            Duration = TimeSpan.FromHours(6),
            AircraftModelId = 2
        },
        new Flight 
        {
            Id = 8,
            Code = "SU108",
            DepartureAirport = "Saint Petersburg",
            ArrivalAirport = "London",
            DepartureDate = new DateTime(2025,10,30,08,00,00),
            ArrivalDate = new DateTime(2025,10,30,09,30,00),
            Duration = TimeSpan.FromHours(1.5),
            AircraftModelId = 1
        },
        new Flight 
        {
            Id = 9,
            Code = "SU109",
            DepartureAirport = "Moscow",
            ArrivalAirport = "Berlin",
            DepartureDate = new DateTime(2025,10,31,11,00,00),
            ArrivalDate = new DateTime(2025,10,31,12,30,00),
            Duration = TimeSpan.FromHours(1.5),
            AircraftModelId = 3
        },
        new Flight 
        {
            Id = 10,
            Code = "SU110",
            DepartureAirport = "Paris",
            ArrivalAirport = "Moscow",
            DepartureDate = new DateTime(2025,11,01,07,00,00),
            ArrivalDate = new DateTime(2025,11,01,10,00,00),
            Duration = TimeSpan.FromHours(3),
            AircraftModelId = 10
        }
    ];

    /// <summary>
    /// Список пассажиров
    /// </summary>
    public List<Passenger> Passengers { get; private set; } = 
    [
        new Passenger
        {
            Id = 1,
            PassportNumber = "P000001",
            FullName = "Ivanov Ivan Ivanovich",
            BirthDate = new DateOnly(1985,1,10)
        },
        new Passenger
        {
            Id = 2,
            PassportNumber = "P000002",
            FullName = "Petrov Petr Petrovich",
            BirthDate = new DateOnly(1990,2,20)
        },
        new Passenger
        {
            Id = 3,
            PassportNumber = "P000003",
            FullName = "Sidorov Sidor Sidorovich",
            BirthDate = new DateOnly(1988,3,15)
        },
        new Passenger
        {
            Id = 4,
            PassportNumber = "P000004",
            FullName = "Kuznetsov Alexey Alexeevich",
            BirthDate = new DateOnly(1992,4,05)
        },
        new Passenger
        {
            Id = 5,
            PassportNumber = "P000005",
            FullName = "Smirnova Anna Sergeevna",
            BirthDate = new DateOnly(1995,5,25) 
        },
        new Passenger
        {
            Id = 6,
            PassportNumber = "P000006",
            FullName = "Volkov Dmitry Ivanovich",
            BirthDate = new DateOnly(1987,6,18) 
        },
        new Passenger
        {
            Id = 7,
            PassportNumber = "P000007",
            FullName = "Lebedev Sergey Nikolaevich",
            BirthDate = new DateOnly(1991,7,30)
        },
        new Passenger
        {
            Id = 8,
            PassportNumber = "P000008",
            FullName = "Morozova Elena Vladimirovna",
            BirthDate = new DateOnly(1993,8,12)
        },
        new Passenger
        {
            Id = 9,
            PassportNumber = "P000009",
            FullName = "Nikolaev Nikolay Ivanovich",
            BirthDate = new DateOnly(1989,9,9) 
        },
        new Passenger
        {
            Id = 10,
            PassportNumber = "P000010",
            FullName = "Fedorova Olga Petrovna",
            BirthDate = new DateOnly(1994,10,2)
        },
        new Passenger
        {
            Id = 11,
            PassportNumber = "P000011",
            FullName = "Orlov Maxim Viktorovich",
            BirthDate = new DateOnly(1984,11,11)
        },
        new Passenger
        {
            Id = 12,
            PassportNumber = "P000012",
            FullName = "Sorokina Marina Igorevna",
            BirthDate = new DateOnly(1996,12,12)
        },
        new Passenger
        {
            Id = 13,
            PassportNumber = "P000013",
            FullName = "Gusev Roman Dmitrievich",
            BirthDate = new DateOnly(1986,6,6) 
        },
        new Passenger
        {
            Id = 14,
            PassportNumber = "P000014",
            FullName = "Markova Irina Sergeevna",
            BirthDate = new DateOnly(1992,9,1) 
        },
        new Passenger
        {
            Id = 15,
            PassportNumber = "P000015",
            FullName = "Nikiforov Alexey Pavlovich",
            BirthDate = new DateOnly(1983,3,3) 
        },
        new Passenger
        {
            Id = 16,
            PassportNumber = "P000016",
            FullName = "Belov Dmitry Sergeevich",
            BirthDate = new DateOnly(1990,4,4) 
        },
        new Passenger
        {
            Id = 17,
            PassportNumber = "P000017",
            FullName = "Karpova Olga Ivanovna",
            BirthDate = new DateOnly(1988,8,8) 
        },
        new Passenger
        {
            Id = 18,
            PassportNumber = "P000018",
            FullName = "Rozov Pavel Anatolievich",
            BirthDate = new DateOnly(1991,1,1) 
        },
        new Passenger
        {
            Id = 19,
            PassportNumber = "P000019",
            FullName = "Simonova Vera Nikolaevna",
            BirthDate = new DateOnly(1997,7,7) 
        },
        new Passenger
        {
            Id = 20,
            PassportNumber = "P000020",
            FullName = "Antonov Ilya Sergeevich",
            BirthDate = new DateOnly(1982,2,2) 
        }
    ];

    /// <summary>
    /// Список билетов
    /// </summary>
    public List<Ticket> Tickets { get; private set; } = 
    [
        new Ticket 
        {
            Id = 1,
            SeatNumber = "1A",
            HasHandLuggage = true,
            BaggageWeight = 0,
            FlightId = 1,
            PassengerId = 1
        },
        new Ticket 
        {
            Id = 2,
            SeatNumber = "1B",
            HasHandLuggage = false,
            BaggageWeight = 12,
            FlightId = 1,
            PassengerId = 2,
        },
        new Ticket 
        {
            Id = 3,
            SeatNumber = "1C",
            HasHandLuggage = true,
            BaggageWeight = 8,
            FlightId = 1,
            PassengerId = 3,
        },
        new Ticket 
        {
            Id = 4,
            SeatNumber = "1D",
            HasHandLuggage = true,
            BaggageWeight = 0,
            FlightId = 1,
            PassengerId = 4,
        },
        new Ticket 
        {
            Id = 5,
            SeatNumber = "1E",
            HasHandLuggage = false,
            BaggageWeight = 15,
            FlightId = 1,
            PassengerId = 5,
        },
        new Ticket 
        {
            Id = 6,
            SeatNumber = "1F",
            HasHandLuggage = true,
            BaggageWeight = 10,
            FlightId = 1,
            PassengerId = 6,
        },
        new Ticket 
        {
            Id = 7,
            SeatNumber = "1G",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 1,
            PassengerId = 7,
        },
        new Ticket 
        {
            Id = 8,
            SeatNumber = "1H",
            HasHandLuggage = true,
            BaggageWeight = 9,
            FlightId = 1,
            PassengerId = 8,
        },
        new Ticket 
        {
            Id = 9,
            SeatNumber = "2A",
            HasHandLuggage = true,
            BaggageWeight = 0,
            FlightId = 2,
            PassengerId = 9,
        },
        new Ticket 
        {
            Id = 10,
            SeatNumber = "2B",
            HasHandLuggage = false,
            BaggageWeight = 11,
            FlightId = 2,
            PassengerId = 10,
        },
        new Ticket 
        {
            Id = 11,
            SeatNumber = "2C",
            HasHandLuggage = true,
            BaggageWeight = 7,
            FlightId = 2,
            PassengerId = 11,
        },
        new Ticket 
        {
            Id = 12,
            SeatNumber = "2D",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 2,
            PassengerId = 12,
        },
        new Ticket 
        {
            Id = 13,
            SeatNumber = "2E",
            HasHandLuggage = true,
            BaggageWeight = 14,
            FlightId = 2,
            PassengerId = 13,
        },
        new Ticket 
        {
            Id = 14,
            SeatNumber = "2F",
            HasHandLuggage = true,
            BaggageWeight = 6,
            FlightId = 2,
            PassengerId = 14,
        },
        new Ticket 
        {
            Id = 15,
            SeatNumber = "2G",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 2,
            PassengerId = 15,
        },
        new Ticket 
        {
            Id = 16,
            SeatNumber = "3A",
            HasHandLuggage = true,
            BaggageWeight = 5,
            FlightId = 3,
            PassengerId = 16,
        },
        new Ticket 
        {
            Id = 17,
            SeatNumber = "3B",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 3,
            PassengerId = 17,
        },
        new Ticket 
        {
            Id = 18,
            SeatNumber = "3C",
            HasHandLuggage = true,
            BaggageWeight = 13,
            FlightId = 3,
            PassengerId = 18,
        },
        new Ticket 
        {
            Id = 19,
            SeatNumber = "3D",
            HasHandLuggage = true,
            BaggageWeight = 0,
            FlightId = 3,
            PassengerId = 19,
        },
        new Ticket 
        {
            Id = 20,
            SeatNumber = "3E",
            HasHandLuggage = false,
            BaggageWeight = 8,
            FlightId = 3,
            PassengerId = 20,
        },
        new Ticket 
        {
            Id = 21,
            SeatNumber = "3F",
            HasHandLuggage = true,
            BaggageWeight = 10,
            FlightId = 3,
            PassengerId = 1,
        },

        new Ticket 
        {
            Id = 22,
            SeatNumber = "4A",
            HasHandLuggage = true,
            BaggageWeight = 0,
            FlightId = 4,
            PassengerId = 2,
        },
        new Ticket 
        {
            Id = 23,
            SeatNumber = "4B",
            HasHandLuggage = false,
            BaggageWeight = 20,
            FlightId = 4,
            PassengerId = 3,
        },
        new Ticket 
        {
            Id = 24,
            SeatNumber = "4C",
            HasHandLuggage = true,
            BaggageWeight = 7,
            FlightId = 4,
            PassengerId = 4,
        },
        new Ticket 
        {
            Id = 25,
            SeatNumber = "4D",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 4,
            PassengerId = 5,
        },
        new Ticket 
        {
            Id = 26,
            SeatNumber = "4E",
            HasHandLuggage = true,
            BaggageWeight = 18,
            FlightId = 4,
            PassengerId = 6,
        },
        new Ticket 
        {
            Id = 27,
            SeatNumber = "5A",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 5,
            PassengerId = 7,
        },
        new Ticket 
        {
            Id = 28,
            SeatNumber = "5B",
            HasHandLuggage = true,
            BaggageWeight = 9,
            FlightId = 5,
            PassengerId = 8,
        },
        new Ticket 
        {
            Id = 29,
            SeatNumber = "5C",
            HasHandLuggage = true,
            BaggageWeight = 12,
            FlightId = 5,
            PassengerId = 9,
        },
        new Ticket 
        {
            Id = 30,
            SeatNumber = "5D",
            HasHandLuggage = false,
            BaggageWeight = 6,
            FlightId = 5,
            PassengerId = 10,
        },
        new Ticket 
        {
            Id = 31,
            SeatNumber = "6A",
            HasHandLuggage = true,
            BaggageWeight = 0,
            FlightId = 6,
            PassengerId = 11,
        },
        new Ticket 
        {
            Id = 32,
            SeatNumber = "6B",
            HasHandLuggage = false,
            BaggageWeight = 11,
            FlightId = 6,
            PassengerId = 12,
        },
        new Ticket {
            Id = 33,
            SeatNumber = "6C",
            HasHandLuggage = true,
            BaggageWeight = 14,
            FlightId = 6,
            PassengerId = 13,
        },
        new Ticket 
        {
            Id = 34,
            SeatNumber = "7A",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 7,
            PassengerId = 14,
        },
        new Ticket 
        {
            Id = 35,
            SeatNumber = "7B",
            HasHandLuggage = true,
            BaggageWeight = 10,
            FlightId = 7,
            PassengerId = 15,
        },
        new Ticket 
        {
            Id = 36,
            SeatNumber = "8A",
            HasHandLuggage = true,
            BaggageWeight = 7,
            FlightId = 8,
            PassengerId = 16,
        },
        new Ticket 
        {
            Id = 37,
            SeatNumber = "8B",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 8,
            PassengerId = 17,
        },

        new Ticket 
        {
            Id = 38,
            SeatNumber = "9A",
            HasHandLuggage = true,
            BaggageWeight = 8,
            FlightId = 9,
            PassengerId = 18,
        },
        new Ticket 
        {
            Id = 39,
            SeatNumber = "9B",
            HasHandLuggage = false,
            BaggageWeight = 0,
            FlightId = 9,
            PassengerId = 19,
        },
        new Ticket 
        {
            Id = 40,
            SeatNumber = "10A",
            HasHandLuggage = true,
            BaggageWeight = 16,
            FlightId = 10,
            PassengerId = 20,
        },
    ];

    /// <summary>
    /// Конструктор устанавливает связи между сущностями
    /// </summary>
    public DataSeeder()
    {
        AircraftModels.ForEach(model =>
            model.AircraftFamily = AircraftFamilies.First(fam => fam.Id == model.AircraftFamilyId));

        AircraftFamilies.ForEach(fam =>
            fam.Models.AddRange(AircraftModels.Where(model => model.AircraftFamilyId == fam.Id)));

        Flights.ForEach(flight =>
            flight.AircraftModel = AircraftModels.First(model => model.Id == flight.AircraftModelId));

        AircraftModels.ForEach(model =>
            model.Flights.AddRange(Flights.Where(flight => flight.AircraftModelId == model.Id)));

        Tickets.ForEach(ticket =>
            ticket.Flight = Flights.First(flight => flight.Id == ticket.FlightId));

        Flights.ForEach(flight =>
            flight.Tickets.AddRange(Tickets.Where(ticket => ticket.FlightId == flight.Id)));

        Tickets.ForEach(ticket =>
            ticket.Passenger = Passengers.First(pass => pass.Id == ticket.PassengerId));

        Passengers.ForEach(pass =>
            pass.Tickets.AddRange(Tickets.Where(ticket => ticket.PassengerId == pass.Id)));
    }
}