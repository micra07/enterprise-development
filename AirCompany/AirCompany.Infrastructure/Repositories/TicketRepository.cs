using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностями <see cref="Ticket"/> в базе данных
/// Предоставляет CRUD-операции через <see cref="AirCompanyDbContext"/>
/// </summary>
public class TicketRepository(AirCompanyDbContext context) : IRepository<Ticket, int>
{
    /// <summary>
    /// Асинхронно добавляет новый билет в базу данных
    /// </summary>
    /// <param name="entity">Объект билета, который необходимо создать</param>
    /// <returns>Созданный объект <see cref="Ticket"/> с присвоенным идентификатором</returns>
    public async Task<Ticket> CreateAsync(Ticket entity)
    {
        var result = await context.Tickets.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Асинхронно удаляет билет по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор билета, которого нужно удалить</param>
    /// <returns>
    /// <see langword="true"/>, если билет был найден и успешно удалён;  
    /// иначе — <see langword="false"/>
    /// </returns>
    public async Task<bool> DeleteAsync(int entityId)
    {
        var entity = await context.Tickets.FirstOrDefaultAsync(e => e.Id == entityId);
        if (entity == null)
            return false;

        context.Tickets.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Асинхронно получает список всех билетов из базы данных
    /// </summary>
    /// <returns>Список объектов <see cref="Ticket"/></returns>
    public async Task<IList<Ticket>> GetAllAsync() =>
        await context.Tickets.ToListAsync();

    /// <summary>
    /// Асинхронно получает билет по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор билета</param>
    /// <returns>
    /// Объект <see cref="Ticket"/>, если найден;  
    /// иначе — <see langword="null"/>
    /// </returns>
    public async Task<Ticket?> GetAsync(int entityId) =>
        await context.Tickets.FirstOrDefaultAsync(e => e.Id == entityId);

    /// <summary>
    /// Асинхронно обновляет данные существующего билета
    /// </summary>
    /// <param name="entity">Обновлённый объект билета</param>
    /// <returns>Обновлённый объект <see cref="Ticket"/> после сохранения изменений</returns>
    public async Task<Ticket> UpdateAsync(Ticket entity)
    {
        context.Tickets.Update(entity);

        await context.SaveChangesAsync();
        return entity;
    }
}