using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностями <see cref="AircraftModel"/> в базе данных
/// Предоставляет CRUD-операции через <see cref="AirCompanyDbContext"/>
/// </summary>
public class AircraftModelRepository(AirCompanyDbContext context) : IRepository<AircraftModel, int>
{
    /// <summary>
    /// Асинхронно добавляет новую модель самолета в базу данных
    /// </summary>
    /// <param name="entity">Объект модели самолета, который необходимо создать</param>
    /// <returns>Созданный объект <see cref="AircraftModel"/> с присвоенным идентификатором</returns>
    public async Task<AircraftModel> CreateAsync(AircraftModel entity)
    {
        var result = await context.AircraftModels.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Асинхронно удаляет модель самолета по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор модели самолета, которого нужно удалить</param>
    /// <returns>
    /// <see langword="true"/>, если модель самолета был найдена и успешно удалена;
    /// иначе — <see langword="false"/>
    /// </returns>
    public async Task<bool> DeleteAsync(int entityId)
    {
        var entity = await context.AircraftModels.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.AircraftModels.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Асинхронно получает список всех моделей из базы данных
    /// </summary>
    /// <returns>Список объектов <see cref="AircraftModel"/></returns>
    public async Task<IList<AircraftModel>> GetAllAsync() =>
        await context.AircraftModels.ToListAsync();

    /// <summary>
    /// Асинхронно получает модель самолета по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор модели самолета</param>
    /// <returns>
    /// Объект <see cref="AircraftModel"/>, если найден;
    /// иначе — <see langword="null"/>
    /// </returns>
    public async Task<AircraftModel?> GetAsync(int entityId) =>
        await context.AircraftModels.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Асинхронно обновляет данные существующей модели самолета
    /// </summary>
    /// <param name="entity">Обновлённый объект модели самолета</param>
    /// <returns>Обновлённый объект <see cref="AircraftModel"/> после сохранения изменений</returns>
    public async Task<AircraftModel> UpdateAsync(AircraftModel entity)
    {
        context.AircraftModels.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}