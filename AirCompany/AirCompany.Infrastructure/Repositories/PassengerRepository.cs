using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностями <see cref="Passenger"/> в базе данных
/// Предоставляет CRUD-операции через <see cref="AirCompanyDbContext"/>
/// </summary>
public class PassengerRepository(AirCompanyDbContext context) : IRepository<Passenger, int>
{
    /// <summary>
    /// Асинхронно добавляет нового пассажира в базу данных
    /// </summary>
    /// <param name="entity">Объект пассажира, который необходимо создать</param>
    /// <returns>Созданный объект <see cref="Passenger"/> с присвоенным идентификатором</returns>
    public async Task<Passenger> CreateAsync(Passenger entity)
    {
        var result = await context.Passengers.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Асинхронно удаляет пассажира по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор пассажира, которого нужно удалить</param>
    /// <returns>
    /// <see langword="true"/>, если пассажир был найден и успешно удалён;  
    /// иначе — <see langword="false"/>
    /// </returns>
    public async Task<bool> DeleteAsync(int entityId)
    {
        var entity = await context.Passengers.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Passengers.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Асинхронно получает список всех пассажиров из базы данных
    /// </summary>
    /// <returns>Список объектов <see cref="Passenger"/></returns>
    public async Task<IList<Passenger>> GetAllAsync() =>
        await context.Passengers.ToListAsync();

    /// <summary>
    /// Асинхронно получает пассажира по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор пассажира</param>
    /// <returns>
    /// Объект <see cref="Passenger"/>, если найден;  
    /// иначе — <see langword="null"/>
    /// </returns>
    public async Task<Passenger?> GetAsync(int entityId) =>
        await context.Passengers.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Асинхронно обновляет данные существующего пассажира
    /// </summary>
    /// <param name="entity">Обновлённый объект пассажира</param>
    /// <returns>Обновлённый объект <see cref="Passenger"/> после сохранения изменений</returns>
    public async Task<Passenger> UpdateAsync(Passenger entity)
    {
        context.Passengers.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}