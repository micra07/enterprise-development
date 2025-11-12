using AirCompany.Domain.Data;
using AirCompany.Domain.Models;

namespace AirCompany.Tests.Fixtures;

/// <summary>
/// Тестовая фикстура для инициализации данных авиакомпании,
/// используется в тестах для создания связей между сущностями,
/// основанных на данных из <see cref="DataSeeder"/>
/// </summary>
public class AirCompanyFixture
{
    /// <summary>
    /// Коллекция семейств самолётов, доступных в тестовых данных
    /// </summary>
    public List<AircraftFamily> AircraftFamilies { get; }

    /// <summary>
    /// Коллекция моделей самолётов, принадлежащих семействам
    /// </summary>
    public List<AircraftModel> AircraftModels { get; }

    /// <summary>
    /// Коллекция пассажиров, участвующих в тестовых рейсах
    /// </summary>
    public List<Passenger> Passengers { get; }

    /// <summary>
    /// Коллекция рейсов авиакомпании
    /// </summary>
    public List<Flight> Flights { get; }

    /// <summary>
    /// Коллекция билетов, связывающих пассажиров с рейсами
    /// </summary>
    public List<Ticket> Tickets { get; }

    /// <summary>
    /// Инициализирует тестовые данные,
    /// формируя связи между сущностями
    /// </summary>
    public AirCompanyFixture()
    {
        AircraftFamilies = [.. DataSeeder.AircraftFamilies];
        AircraftModels = [.. DataSeeder.AircraftModels];
        Passengers = [.. DataSeeder.Passengers];
        Flights = [.. DataSeeder.Flights];
        Tickets = [.. DataSeeder.Tickets];

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