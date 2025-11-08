using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Models;

/// <summary>
/// Авиарейс содержит сведения о коде рейса, пунктах отправления и прибытия, датах, времени полета и модели самолета
/// </summary>
[Table("flights")]
public class Flight
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("id")] 
    public required int Id { get; set; }

    /// <summary>
    /// Код рейса (например, SU123)
    /// </summary>
    [Column("code")] 
    public required string Code { get; set; }

    /// <summary>
    /// Аэропорт отправления
    /// </summary>
    [Column("departure_airport")] 
    public required string DepartureAirport { get; set; }

    /// <summary>
    /// Аэропорт прибытия
    /// </summary>
    [Column("arrival_airport")]
    public required string ArrivalAirport { get; set; }

    /// <summary>
    /// Дата отправления рейса
    /// </summary>
    [Column("departure_datetime")]
    public DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Дата прибытия рейса
    /// </summary>
    [Column("arrival_datetime")]
    public DateTime? ArrivalDate { get; set; }

    /// <summary>
    /// Длительность рейса
    /// </summary>
    [Column("duration")]
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Идентификатор модели самолета, на которой выполняется рейс
    /// </summary>
    [Column("aircraft_model_id")]
    public required int AircraftModelId { get; set; }

    /// <summary>
    /// Модель самолета, на которой выполняется рейс
    /// </summary>
    public AircraftModel? AircraftModel { get; set; }

    /// <summary>
    /// Список билетов, купленных на данный рейс
    /// </summary>
    public List<Ticket> Tickets { get; set; } = [];
}