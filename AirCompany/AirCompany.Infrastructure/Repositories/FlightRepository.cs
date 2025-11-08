using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностями <see cref="Flight"/> в базе данных
/// Предоставляет CRUD-операции через <see cref="AirCompanyDbContext"/>
/// </summary>
public class FlightRepository(AirCompanyDbContext context) : IRepository<Flight, int>
{
    /// <summary>
    /// Асинхронно добавляет новый полёт в базу данных
    /// </summary>
    /// <param name="entity">Объект полёта, который необходимо создать</param>
    /// <returns>Созданный объект <see cref="Flight"/> с присвоенным идентификатором</returns>
    public async Task<Flight> CreateAsync(Flight entity)
    {
        var result = await context.Flights.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Асинхронно удаляет полёт по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор полёта, которого нужно удалить</param>
    /// <returns>
    /// <see langword="true"/>, если полёт был найден и успешно удалён;  
    /// иначе — <see langword="false"/>
    /// </returns>
    public async Task<bool> DeleteAsync(int entityId)
    {
        var entity = await context.Flights.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Flights.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Асинхронно получает список всех полётов из базы данных
    /// </summary>
    /// <returns>Список объектов <see cref="Flight"/></returns>
    public async Task<IList<Flight>> GetAllAsync() =>
        await context.Flights.ToListAsync();

    /// <summary>
    /// Асинхронно получает полёт по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор полёта</param>
    /// <returns>
    /// Объект <see cref="Flight"/>, если найден;  
    /// иначе — <see langword="null"/>
    /// </returns>
    public async Task<Flight?> GetAsync(int entityId) =>
        await context.Flights.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Асинхронно обновляет данные существующего полёта
    /// </summary>
    /// <param name="entity">Обновлённый объект полёта</param>
    /// <returns>Обновлённый объект <see cref="Flight"/> после сохранения изменений</returns>
    public async Task<Flight> UpdateAsync(Flight entity)
    {
        context.Flights.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}