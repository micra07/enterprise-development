namespace AirCompany.Application.Contracts.Dtos.Passengers;

/// <summary>
/// DTO для создания или обновления пассажира
/// </summary>
/// <param name="PassportNumber">Номер паспорта</param>
/// <param name="FullName">ФИО пассажира</param>
/// <param name="BirthDate">Дата рождения</param>
public record PassengerCreateUpdateDto(string PassportNumber, string FullName, DateOnly? BirthDate);