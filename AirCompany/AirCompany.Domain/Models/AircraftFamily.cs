using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Models;

/// <summary>
/// Семейство самолетов (справочник) содержит название семейства и производителя, а также список моделей, относящихся к этому семейству
/// </summary>
[Table("aircraft_families")]
public class AircraftFamily
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Производитель
    /// </summary>
    [Column("manufacturer")]
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Список моделей, принадлежащих этому семейству
    /// </summary>
    public List<AircraftModel> Models { get; set; } = [];
}