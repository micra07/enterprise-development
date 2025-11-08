namespace AirCompany.Application.Contracts.Dtos.AircraftModels;

/// <summary>
/// DTO для получения модели самолета
/// </summary>
/// <param name="Id">Идентификатор модели</param>
/// <param name="Name">Название модели</param>
/// <param name="FlightRange">Дальность полета в км</param>
/// <param name="PassengerCapacity">Пассажировместимость</param>
/// <param name="CargoCapacity">Грузоподъемность в кг</param>
/// <param name="AircraftFamilyId">Идентификатор семейства</param>
public record AircraftModelDto(int Id, string Name, double FlightRange, int PassengerCapacity, double CargoCapacity, int AircraftFamilyId);