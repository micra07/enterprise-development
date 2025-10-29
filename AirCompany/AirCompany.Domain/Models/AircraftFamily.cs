namespace AirCompany.Domain.Models;

/// <summary>
/// Семейство самолетов (справочник) содержит название семейства и производителя, а также список моделей, относящихся к этому семейству
/// </summary>
public class AircraftFamily
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Производитель
    /// </summary>
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Список моделей, принадлежащих этому семейству
    /// </summary>
    public List<AircraftModel> Models { get; set; } = [];
}