using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Dtos.Passengers;
using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Контроллер аналитических запросов для авиакомпании
/// </summary>
/// <param name="service">Сервис аналитики</param>
/// <param name="logger">Логгер для отслеживания действий и ошибок</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(
    IAnalyticsService service,
    ILogger<AnalyticsController> logger
) : ControllerBase
{
    /// <summary>
    /// Получить топ-5 рейсов по количеству пассажиров
    /// </summary>
    [HttpGet("top-flights")]
    [ProducesResponseType(typeof(IList<FlightDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightsWithPassengersCountDto>>> GetTopFlightsByPassengerCount()
    {
        try
        {
            var flights = await service.GetTopFlightsByPassengerCount();
            logger.LogInformation("Retrieved top 5 flights by passenger count");
            return Ok(flights);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Method} of {Controller}", nameof(GetTopFlightsByPassengerCount), nameof(AnalyticsController));
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получить рейсы с минимальной продолжительностью полета
    /// </summary>
    [HttpGet("minimal-duration")]
    [ProducesResponseType(typeof(IList<FlightDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsWithMinimalDuration()
    {
        try
        {
            var flights = await service.GetFlightsWithMinimalDuration();
            logger.LogInformation("Retrieved flights with minimal duration");
            return Ok(flights);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Method} of {Controller}", nameof(GetFlightsWithMinimalDuration), nameof(AnalyticsController));
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получить пассажиров рейса, вес багажа которых равен нулю
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    [HttpGet("passengers/{flightId:int}")]
    [ProducesResponseType(typeof(IList<PassengerDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<PassengerDto>>> GetPassengersByFlight(int flightId)
    {
        try
        {
            var passengers = await service.GetPassengersByFlight(flightId);
            if (passengers == null || passengers.Count == 0)
            {
                logger.LogWarning("No passengers found for flight {FlightId}", flightId);
                return NotFound($"No passengers found for flight {flightId}");
            }

            logger.LogInformation("Retrieved passengers for flight {FlightId}", flightId);
            return Ok(passengers);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Method} of {Controller}", nameof(GetPassengersByFlight), nameof(AnalyticsController));
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получить рейсы по модели самолета за указанный период
    /// </summary>
    /// <param name="aircraftModelId">Идентификатор модели самолета</param>
    /// <param name="startTime">Дата начала периода</param>
    /// <param name="endTime">Дата конца периода</param>
    [HttpGet("flights/model/{aircraftModelId:int}")]
    [ProducesResponseType(typeof(IList<FlightDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsByAircraftModelInPeriod(
        int aircraftModelId,
        [FromQuery] DateTime startTime,
        [FromQuery] DateTime endTime)
    {
        try
        {
            var flights = await service.GetFlightsByAircraftModelInPeriod(aircraftModelId, startTime, endTime);
            if (flights == null || flights.Count == 0)
            {
                logger.LogWarning("No flights found for model {ModelId} in specified period", aircraftModelId);
                return NotFound($"No flights found for model {aircraftModelId} in specified period");
            }

            logger.LogInformation("Retrieved {Count} flights for model {ModelId} in period", flights.Count, aircraftModelId);
            return Ok(flights);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Method} of {Controller}", nameof(GetFlightsByAircraftModelInPeriod), nameof(AnalyticsController));
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получить рейсы по маршруту (аэропорт отправления и прибытия)
    /// </summary>
    /// <param name="departure">Аэропорт отправления</param>
    /// <param name="arrival">Аэропорт прибытия</param>
    [HttpGet("flights/route")]
    [ProducesResponseType(typeof(IList<FlightDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<FlightDto>>> GetFlightsByRoute([FromQuery] string departure, [FromQuery] string arrival)
    {
        try
        {
            var flights = await service.GetFlightsByRoute(departure, arrival);
            if (flights == null || flights.Count == 0)
            {
                logger.LogWarning("No flights found from {Departure} to {Arrival}", departure, arrival);
                return NotFound($"No flights found from {departure} to {arrival}");
            }

            logger.LogInformation("Retrieved {Count} flights from {Departure} to {Arrival}", flights.Count, departure, arrival);
            return Ok(flights);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in {Method} of {Controller}", nameof(GetFlightsByRoute), nameof(AnalyticsController));
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }
}