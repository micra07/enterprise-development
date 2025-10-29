namespace AirCompany.Domain.Models;

/// <summary>
/// Модель самолета (справочник) содержит характеристики модели, вместимость, грузоподъемность и связь с семейством самолетов
/// </summary>
public class AircraftModel
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
    /// Дальность полета самолета (в километрах)
    /// </summary>
    public required double FlightRange { get; set; }

    /// <summary>
    /// Пассажировместимость самолета
    /// </summary>
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Грузоподъемность самолета (в килограммах)
    /// </summary>
    public required double CargoCapacity { get; set; }

    /// <summary>
    /// Идентификатор семейства самолета, к которому относится модель
    /// </summary>
    public required int AircraftFamilyId { get; set; }

    /// <summary>
    /// Семейство самолета, к которому относится данная модель
    /// </summary>
    public AircraftFamily? AircraftFamily { get; set; }

    /// <summary>
    /// Список рейсов, выполняемых на данной модели самолета
    /// </summary>
    public List<Flight> Flights { get; set; } = [];
}