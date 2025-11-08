namespace AirCompany.Application.Contracts.Dtos.AircraftFamilies;

/// <summary>
/// DTO для создания или обновления семейства самолетов
/// </summary>
/// <param name="Name">Название семейства</param>
/// <param name="Manufacturer">Производитель</param>
public record AircraftFamilyCreateUpdateDto(string Name, string Manufacturer);