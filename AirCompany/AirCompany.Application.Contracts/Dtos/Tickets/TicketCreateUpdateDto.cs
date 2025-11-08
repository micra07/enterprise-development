namespace AirCompany.Application.Contracts.Dtos.Tickets;

/// <summary>
/// DTO для создания или обновления билета
/// </summary>
/// <param name="SeatNumber">Номер места</param>
/// <param name="HasHandLuggage">Есть ли ручная кладь</param>
/// <param name="BaggageWeight">Вес багажа</param>
/// <param name="FlightId">Идентификатор рейса</param>
/// <param name="PassengerId">Идентификатор пассажира</param>
public record TicketCreateUpdateDto(string SeatNumber, bool? HasHandLuggage, double? BaggageWeight, int FlightId, int PassengerId);