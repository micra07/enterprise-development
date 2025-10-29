using AirCompany.Domain.Data;

namespace AirCompany.Tests;

/// <summary>
/// Юнит-тесты для проверки корректности работы доменной модели авиакомпании, используется статический датасет из DataSeeder
/// </summary>
public class DomainTests(DataSeeder seeder): IClassFixture<DataSeeder>
{
    /// <summary>
    /// Проверяет, что топ-5 рейсов по количеству пассажиров возвращается корректно
    /// Сравниваются Id рейсов и порядок по количеству билетов
    /// </summary>
    [Fact]
    public void GetTopFlightsByPassengerCount_WhenCalled_ReturnsTop5Flights()
    {
        var expectedIds = new List<int> { 1, 2, 3, 4, 5 };
        var top5 = seeder.Flights
            .OrderByDescending(f => f.Tickets!.Count)
            .Take(5)
            .ToList();

        Assert.Equal(5, top5.Count);
        Assert.Equal(expectedIds, [.. top5.Select(f => f.Id)]);
    }

    /// <summary>
    /// Проверяет, что список рейсов с минимальной продолжительностью полета возвращается корректно
    /// Сравниваются Id рейсов и значение Duration
    /// </summary>
    [Fact]
    public void GetFlightsWithMinimalDuration_WhenFlightsExist_ReturnsAllWithMinDuration()
    {
        var expectedIds = new List<int> { 3, 6, 8, 9 };
        var minDuration = seeder.Flights.Where(f => f.Duration != null).Min(f => f.Duration);
        var flights = seeder.Flights
            .Where(f => f.Duration == minDuration)
            .ToList();

        Assert.NotEmpty(flights);
        Assert.Equal(expectedIds, [.. flights.Select(f => f.Id).OrderBy(id => id)]);
    }

    /// <summary>
    /// Проверяет, что пассажиры с нулевым багажом на указанном рейсе возвращаются
    /// и сортируются по ФИО
    /// Использует [Theory] для проверки разных FlightId
    /// </summary>
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void GetPassengersByFlight_WhenBaggageWeightIsZero_ReturnsSortedByFullName(int flightId)
    {
        var expectedPassengerIds = flightId switch
        {
            1 => [1, 4, 7],
            2 => [15, 9, 12],
            3 => [17, 19],
            4 => [2, 5],
            5 => [7],
            _ => new List<int>()
        };
        var passengers = seeder.Tickets
            .Where(t => t.FlightId == flightId && (t.BaggageWeight ?? 0) == 0)
            .Select(t => t.Passenger)
            .OrderBy(p => p!.FullName)
            .ToList();

        Assert.All(passengers, p => Assert.True(p != null));
        Assert.Equal(expectedPassengerIds, [.. passengers.Select(p => p!.Id)]);
    }

    /// <summary>
    /// Проверяет, что все рейсы заданной модели самолета в указанном периоде возвращаются корректно
    /// Сравниваются Id рейсов и соответствие датам
    /// </summary>
    [Fact]
    public void GetFlightsByAircraftModel_WhenWithinSpecifiedPeriod_ReturnsMatchingFlights()
    {
        var modelId = 5;
        var expectedIds = new List<int> { 4, 5 };
        var start = new DateTime(2025, 10, 27);
        var end = new DateTime(2025, 10, 29);

        var flights = seeder.Flights
            .Where(f => f.AircraftModelId == modelId
                        && f.DepartureDate >= start
                        && f.DepartureDate <= end)
            .ToList();

        Assert.NotEmpty(flights);
        Assert.Equal(expectedIds, [.. flights.Select(f => f.Id).OrderBy(id => id)]);
    }

    /// <summary>
    /// Проверяет, что все рейсы, вылетающие из указанного пункта отправления в указанный пункт прибытия, возвращаются корректно
    /// Сравниваются Id рейсов и соответствие аэропортам
    /// </summary>
    [Fact]
    public void GetFlightsByRoute_WhenDepartureAndArrivalMatch_ReturnsCorrectFlights()
    {
        var departure = "Moscow";
        var arrival = "London";

        var flights = seeder.Flights
            .Where(f => f.DepartureAirport == departure && f.ArrivalAirport == arrival)
            .ToList();

        Assert.Single(flights);

        Assert.All(flights, f =>
        {
            Assert.Equal(departure, f.DepartureAirport);
            Assert.Equal(arrival, f.ArrivalAirport);
        });
    }
}