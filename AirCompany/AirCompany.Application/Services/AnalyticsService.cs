using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Dtos.Passengers;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using AutoMapper;

namespace AirCompany.Application.Services;

/// <summary>
/// Сервис аналитики авиакомпании
/// Выполняет запросы для получения информации о рейсах и пассажирах
/// </summary>
public class AnalyticsService(IRepository<Flight, int> repository, IMapper mapper) : IAnalyticsService
{
    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlightsByAircraftModelInPeriod(int aircraftModelId, DateTime startTime, DateTime endTime)
    {
        var flights = await repository.GetAllAsync();
        var result = flights
            .Where(f => f.AircraftModelId == aircraftModelId
                        && f.DepartureDate >= startTime
                        && f.DepartureDate <= endTime)
            .OrderBy(f => f.Id)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlightsByRoute(string departure, string arrival)
    {
        var flights = await repository.GetAllAsync();
        var result = flights
            .Where(f => f.DepartureAirport == departure && f.ArrivalAirport == arrival)
            .OrderBy(f => f.Id)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetFlightsWithMinimalDuration()
    {
        var flights = await repository.GetAllAsync();
        var minDuration = flights.Where(f => f.Duration != null).Min(f => f.Duration);
        var result = flights
            .Where(f => f.Duration == minDuration)
            .OrderBy(f => f.Id)
            .ToList();

        return mapper.Map<List<FlightDto>>(result);
    }

    /// <inheritdoc/>
    public async Task<IList<PassengerDto>> GetPassengersByFlight(int flightId)
    {
        var flights = await repository.GetAllAsync();
        var flight = flights.FirstOrDefault(f => f.Id == flightId)
                     ?? throw new KeyNotFoundException($"Flight {flightId} not found");

        var passengers = flight.Tickets?
            .Where(t => (t.BaggageWeight ?? 0) == 0)
            .Select(t => t.Passenger)
            .Where(p => p != null)
            .OrderBy(p => p!.FullName)
            .ToList() ?? [];

        return mapper.Map<List<PassengerDto>>(passengers);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetTopFlightsByPassengerCount()
    {
        var flights = await repository.GetAllAsync();
        var top5 = flights
            .OrderByDescending(f => f.Tickets?.Count ?? 0)
            .Take(5)
            .ToList();

        return mapper.Map<List<FlightDto>>(top5);
    }
}