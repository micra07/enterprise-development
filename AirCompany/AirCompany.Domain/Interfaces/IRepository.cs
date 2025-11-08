namespace AirCompany.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория для CRUD операций
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип идентификатора сущности</typeparam>
public interface IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : struct
{
    /// <summary>
    /// Создание новой сущности
    /// </summary>
    /// <param name="entity">Новая сущность</param>
    public Task<TEntity> CreateAsync(TEntity entity);

    /// <summary>
    /// Получение сущности по идентификатору
    /// </summary>
    /// <param name="entityId">Идентификатор сущности</param>
    /// <returns>Сущность</returns>
    public Task<TEntity?> GetAsync(TKey entityId);

    /// <summary>
    /// Получение всего списка сущностей
    /// </summary> 
    /// <returns></returns>
    public Task<IList<TEntity>> GetAllAsync();

    /// <summary>
    /// Обновление сущности в коллекции
    /// </summary>
    /// <param name="entity">Отредактированная сущность</param>
    public Task<TEntity> UpdateAsync(TEntity entity);

    /// <summary>
    /// Удаление сущности из коллекции
    /// </summary>
    /// <param name="entityId">Идентификатор сущности</param>
    public Task<bool> DeleteAsync(TKey entityId);
}