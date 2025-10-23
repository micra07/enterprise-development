namespace AirCompany.Domain.Models;

/// <summary>
/// Пассажир содержит сведения о паспорте, ФИО и дате рождения, а также список билетов пассажира
/// </summary>
public class Passenger
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Дата рождения пассажира
    /// </summary>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Список билетов, купленных пассажиром
    /// </summary>
    public List<Ticket>? Tickets { get; set; } = [];
}