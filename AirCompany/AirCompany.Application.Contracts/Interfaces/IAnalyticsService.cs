using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Dtos.Passengers;

namespace AirCompany.Application.Contracts.Interfaces;

/// <summary>
/// Интерфейс аналитического сервиса авиакомпании
/// Предоставляет методы для получения аналитической информации о рейсах и пассажирах
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Возвращает список рейсов с наибольшим количеством пассажиров
    /// </summary>
    /// <returns>
    /// Список объектов <see cref="FlightDto"/>, отсортированных по количеству пассажиров в порядке убывания
    /// </returns>
    public Task<IList<FlightDto>> GetTopFlightsByPassengerCount();

    /// <summary>
    /// Возвращает список рейсов с минимальной продолжительностью полёта
    /// </summary>
    /// <returns>
    /// Список объектов <see cref="FlightDto"/> с наименьшим временем между вылетом и прилётом
    /// </returns>
    public Task<IList<FlightDto>> GetFlightsWithMinimalDuration();

    /// <summary>
    /// Возвращает список пассажиров, зарегистрированных на указанный рейс
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>
    /// Список объектов <see cref="PassengerDto"/>, относящихся к заданному рейсу
    /// </returns>
    public Task<IList<PassengerDto>> GetPassengersByFlight(int flightId);

    /// <summary>
    /// Возвращает список рейсов, выполненных на определённой модели самолёта в заданный период времени
    /// </summary>
    /// <param name="aircraftModelId">Идентификатор модели самолёта</param>
    /// <param name="startTime">Начало временного диапазона</param>
    /// <param name="endTime">Конец временного диапазона</param>
    /// <returns>
    /// Список объектов <see cref="FlightDto"/>, соответствующих заданным параметрам
    /// </returns>
    public Task<IList<FlightDto>> GetFlightsByAircraftModelInPeriod(int aircraftModelId, DateTime startTime, DateTime endTime);

    /// <summary>
    /// Возвращает список рейсов по заданному маршруту
    /// </summary>
    /// <param name="departure">Название аэропорта вылета</param>
    /// <param name="arrival">Название аэропорта прибытия</param>
    /// <returns>
    /// Список объектов <see cref="FlightDto"/>, соответствующих указанному маршруту
    /// </returns>
    public Task<IList<FlightDto>> GetFlightsByRoute(string departure, string arrival);
}