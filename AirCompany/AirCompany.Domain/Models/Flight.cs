namespace AirCompany.Domain.Models;

/// <summary>
/// Авиарейс содержит сведения о коде рейса, пунктах отправления и прибытия, датах, времени полета и модели самолета
/// </summary>
public class Flight
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Код рейса (например, SU123)
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// Аэропорт отправления
    /// </summary>
    public required string DepartureAirport { get; set; }

    /// <summary>
    /// Аэропорт прибытия
    /// </summary>
    public required string ArrivalAirport { get; set; }

    /// <summary>
    /// Дата отправления рейса
    /// </summary>
    public DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Дата прибытия рейса
    /// </summary>
    public DateTime? ArrivalDate { get; set; }

    /// <summary>
    /// Длительность рейса
    /// </summary>
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Идентификатор модели самолета, на которой выполняется рейс
    /// </summary>
    public required int AircraftModelId { get; set; }

    /// <summary>
    /// Модель самолета, на которой выполняется рейс
    /// </summary>
    public AircraftModel? AircraftModel { get; set; }

    /// <summary>
    /// Список билетов, купленных на данный рейс
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}