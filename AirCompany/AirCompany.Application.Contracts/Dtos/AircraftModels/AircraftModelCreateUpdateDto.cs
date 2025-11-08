namespace AirCompany.Application.Contracts.Dtos.AircraftModels;

/// <summary>
/// DTO для создания или обновления модели самолета
/// </summary>
/// <param name="Name">Название модели</param>
/// <param name="FlightRange">Дальность полета в км</param>
/// <param name="PassengerCapacity">Пассажировместимость</param>
/// <param name="CargoCapacity">Грузоподъемность в кг</param>
/// <param name="AircraftFamilyId">Идентификатор семейства</param>
public record AircraftModelCreateUpdateDto(string Name, double FlightRange, int PassengerCapacity, double CargoCapacity, int AircraftFamilyId);