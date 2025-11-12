namespace AirCompany.Application.Contracts.Dtos.Flights;

/// <summary>
/// Расширенный <see cref="FlightDto"/> с добавлением количества пассажиров
/// </summary>
/// <param name="Flight">Объект <see cref="FlightDto"/></param>
/// <param name="PassengerCount">Количество пассажиров</param>
public record FlightsWithPassengersCountDto(FlightDto Flight, int PassengerCount);