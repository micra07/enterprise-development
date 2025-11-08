namespace AirCompany.Application.Contracts.Dtos.Passengers;

/// <summary>
/// DTO для получения пассажира
/// </summary>
/// <param name="Id">Идентификатор пассажира</param>
/// <param name="PassportNumber">Номер паспорта</param>
/// <param name="FullName">ФИО пассажира</param>
/// <param name="BirthDate">Дата рождения</param>
public record PassengerDto(int Id, string PassportNumber, string FullName, DateOnly? BirthDate);