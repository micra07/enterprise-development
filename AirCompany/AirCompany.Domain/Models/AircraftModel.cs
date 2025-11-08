using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Models;

/// <summary>
/// Модель самолета (справочник) содержит характеристики модели, вместимость, грузоподъемность и связь с семейством самолетов
/// </summary>
[Table("aircraft_models")]
public class AircraftModel
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
    /// Дальность полета самолета (в километрах)
    /// </summary>
    [Column("flight_range")]
    public required double FlightRange { get; set; }

    /// <summary>
    /// Пассажировместимость самолета
    /// </summary>
    [Column("passenger_capacity")]
    public required int PassengerCapacity { get; set; }

    /// <summary>
    /// Грузоподъемность самолета (в килограммах)
    /// </summary>
    [Column("cargo_capacity")]
    public required double CargoCapacity { get; set; }

    /// <summary>
    /// Идентификатор семейства самолета, к которому относится модель
    /// </summary>
    [Column("aircraft_family_id")]
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