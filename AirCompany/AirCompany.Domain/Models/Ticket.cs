namespace AirCompany.Domain.Models;

/// <summary>
/// Билет содержит сведения о рейсе, пассажире, номере сидения, ручной клади и весе багажа
/// </summary>
public class Ticket
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер сидения пассажира в самолете
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Наличие ручной клади
    /// </summary>
    public bool? HasHandLuggage { get; set; }

    /// <summary>
    /// Суммарный вес багажа пассажира (в килограммах)
    /// </summary>
    public double? BaggageWeight { get; set; }

    /// <summary>
    /// Идентификатор рейса, на который куплен билет
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Рейс, на который куплен билет
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Идентификатор пассажира, который купил билет
    /// </summary>
    public required int PassengerId { get; set; }

    /// <summary>
    /// Пассажир, купивший билет
    /// </summary>
    public Passenger? Passenger { get; set; }
}