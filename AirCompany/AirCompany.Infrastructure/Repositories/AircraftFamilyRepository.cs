using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностями <see cref="AircraftFamily"/> в базе данных
/// Предоставляет CRUD-операции через <see cref="AirCompanyDbContext"/>
/// </summary>
public class AircraftFamilyRepository(AirCompanyDbContext context) : IRepository<AircraftFamily, int>
{
    /// <summary>
    /// Асинхронно добавляет новое семейство самолета в базу данных
    /// </summary>
    /// <param name="entity">Объект семейства самолета, который необходимо создать</param>
    /// <returns>Созданный объект <see cref="AircraftFamily"/> с присвоенным идентификатором</returns>
    public async Task<AircraftFamily> CreateAsync(AircraftFamily entity)
    {
        var result = await context.AircraftFamilies.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Асинхронно удаляет семейство самолета по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор семейства самолета, которого нужно удалить</param>
    /// <returns>
    /// <see langword="true"/>, если семейство самолета был найдено и успешно удалено;
    /// иначе — <see langword="false"/>
    /// </returns>
    public async Task<bool> DeleteAsync(int entityId)
    {
        var entity = await context.AircraftFamilies.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.AircraftFamilies.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Асинхронно получает список всех семейств из базы данных
    /// </summary>
    /// <returns>Список объектов <see cref="AircraftFamily"/></returns>
    public async Task<IList<AircraftFamily>> GetAllAsync() =>
        await context.AircraftFamilies.ToListAsync();

    /// <summary>
    /// Асинхронно получает семейство самолета по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор семейства самолета</param>
    /// <returns>
    /// Объект <see cref="AircraftFamily"/>, если найден;
    /// иначе — <see langword="null"/>
    /// </returns>
    public async Task<AircraftFamily?> GetAsync(int entityId) =>
        await context.AircraftFamilies.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Асинхронно обновляет данные существующего семейство самолета
    /// </summary>
    /// <param name="entity">Обновлённый объект семейства самолета</param>
    /// <returns>Обновлённый объект <see cref="AircraftFamily"/> после сохранения изменений</returns>
    public async Task<AircraftFamily> UpdateAsync(AircraftFamily entity)
    {
        context.AircraftFamilies.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}