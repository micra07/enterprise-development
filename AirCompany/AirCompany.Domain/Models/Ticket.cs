using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Models;

/// <summary>
/// Билет содержит сведения о рейсе, пассажире, номере сидения, ручной клади и весе багажа
/// </summary>
[Table("tickets")]
public class Ticket
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер сидения пассажира в самолете
    /// </summary>
    [Column("seat_number")]
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Наличие ручной клади
    /// </summary>
    [Column("has_hand_luggage")]
    public bool? HasHandLuggage { get; set; }

    /// <summary>
    /// Суммарный вес багажа пассажира (в килограммах)
    /// </summary>
    [Column("baggage_weight")]
    public double? BaggageWeight { get; set; }

    /// <summary>
    /// Идентификатор рейса, на который куплен билет
    /// </summary>
    [Column("flight_id")]
    public required int FlightId { get; set; }

    /// <summary>
    /// Рейс, на который куплен билет
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Идентификатор пассажира, который купил билет
    /// </summary>
    [Column("passenger_id")]
    public required int PassengerId { get; set; }

    /// <summary>
    /// Пассажир, купивший билет
    /// </summary>
    public Passenger? Passenger { get; set; }
}