namespace AirCompany.Application.Contracts.Dtos.Flights;

/// <summary>
/// DTO для создания или обновления авиарейса
/// </summary>
/// <param name="Code">Код рейса</param>
/// <param name="DepartureAirport">Аэропорт вылета</param>
/// <param name="ArrivalAirport">Аэропорт прибытия</param>
/// <param name="DepartureDate">Дата и время вылета</param>
/// <param name="ArrivalDate">Дата и время прибытия</param>
/// <param name="Duration">Длительность рейса</param>
/// <param name="AircraftModelId">Идентификатор модели самолета</param>
public record FlightCreateUpdateDto(string Code, string DepartureAirport, string ArrivalAirport, DateTime? DepartureDate, DateTime? ArrivalDate, TimeSpan? Duration, int AircraftModelId);