using AirCompany.Domain.Data;

namespace AirCompany.Tests;

public class DomainTests(DataSeeder seeder): IClassFixture<DataSeeder>
{
    [Fact]
    public void Top5FlightsByPassengerCount_ShouldReturnCorrectFlights()
    {
        var expectedIds = new List<int> { 1, 2, 3, 4, 5 };
        var top5 = seeder.Flights
            .OrderByDescending(f => f.Tickets!.Count)
            .Take(5)
            .ToList();

        Assert.Equal(5, top5.Count);
        Assert.True(top5[0].Tickets!.Count >= top5[4].Tickets!.Count);
        Assert.Equal(expectedIds, [.. top5.Select(f => f.Id)]);
    }

    [Fact]
    public void FlightsWithMinimalDuration_ShouldReturnAllMinDurationFlights()
    {
        var expectedIds = new List<int> { 3, 6, 8, 9 };
        var minDuration = seeder.Flights.Min(f => f.Duration ?? TimeSpan.MaxValue);
        var flights = seeder.Flights
            .Where(f => f.Duration == minDuration)
            .ToList();

        Assert.NotEmpty(flights);
        Assert.All(flights, f => Assert.Equal(minDuration, f.Duration));
        Assert.Equal(expectedIds, [.. flights.Select(f => f.Id).OrderBy(id => id)]);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void PassengersWithZeroBaggage_OnFlight_ShouldReturnSortedByFullName(int flightId)
    {
        var passengers = seeder.Tickets
            .Where(t => t.FlightId == flightId && (t.BaggageWeight ?? 0) == 0)
            .Select(t => t.Passenger)
            .OrderBy(p => p!.FullName)
            .ToList();

        Assert.All(passengers, p => Assert.True(p != null));

        var expectedPassengerIds = flightId switch
        {
            1 => [1, 4, 7],
            2 => [15, 9, 12],
            _ => new List<int>()
        };

        Assert.Equal(expectedPassengerIds, [.. passengers.Select(p => p!.Id)]);
    }

    [Fact]
    public void FlightsByAircraftModelInPeriod_ShouldReturnCorrectFlights()
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

    [Fact]
    public void FlightsFromTo_ShouldReturnCorrectFlights()
    {
        var departure = "Moscow";
        var arrival = "London";

        var flights = seeder.Flights
            .Where(f => f.DepartureAirport == departure && f.ArrivalAirport == arrival)
            .ToList();

        Assert.NotEmpty(flights);
        Assert.All(flights, f =>
        {
            Assert.Equal(departure, f.DepartureAirport);
            Assert.Equal(arrival, f.ArrivalAirport);
        });
    }
}