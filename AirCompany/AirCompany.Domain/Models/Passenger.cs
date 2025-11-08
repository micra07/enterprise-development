using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Models;

/// <summary>
/// Пассажир содержит сведения о паспорте, ФИО и дате рождения, а также список билетов пассажира
/// </summary>
[Table("passengers")]
public class Passenger
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("id")] 
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира
    /// </summary>
    [Column("passport_number")]
    public required string PassportNumber { get; set; }

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    [Column("full_name")]
    public required string FullName { get; set; }

    /// <summary>
    /// Дата рождения пассажира
    /// </summary>
    [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Список билетов, купленных пассажиром
    /// </summary>
    public List<Ticket> Tickets { get; set; } = [];
}