namespace AirCompany.Application.Contracts.Dtos.Tickets;

/// <summary>
/// DTO для получения билета
/// </summary>
/// <param name="Id">Идентификатор билета</param>
/// <param name="SeatNumber">Номер места</param>
/// <param name="HasHandLuggage">Есть ли ручная кладь</param>
/// <param name="BaggageWeight">Вес багажа</param>
/// <param name="FlightId">Идентификатор рейса</param>
/// <param name="PassengerId">Идентификатор пассажира</param>
public record TicketDto(int Id, string SeatNumber, bool? HasHandLuggage, double? BaggageWeight, int FlightId, int PassengerId);