using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Базовый контроллер, реализующий CRUD-операции для сущностей
/// </summary>
/// <typeparam name="TDto">DTO сущности</typeparam>
/// <typeparam name="TCreateUpdateDto">DTO для создания/обновления сущности</typeparam>
/// <typeparam name="TKey">Тип ключа сущности</typeparam>
[Route("api/[controller]")]
[ApiController]
public class CrudControllerBase<TDto, TCreateUpdateDto, TKey>(
    IApplicationService<TDto, TCreateUpdateDto, TKey> appService,
    ILogger<CrudControllerBase<TDto, TCreateUpdateDto, TKey>> logger
) : ControllerBase
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    /// <summary>
    /// Получить все записи
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<TDto>>> GetAll()
    {
        try
        {
            var items = await appService.GetAll();
            logger.LogInformation("Retrieved {Count} items in {Controller}", items.Count, GetType().Name);
            return Ok(items);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {Method} method of {Controller}", nameof(GetAll), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<TDto>> Get(TKey id)
    {
        try
        {
            var item = await appService.Get(id);
            logger.LogInformation("Retrieved item {Id} in {Controller}", id, GetType().Name);
            return Ok(item);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning(ex, "Item with ID {Id} not found in {Controller}", id, GetType().Name);
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {Method} method of {Controller}", nameof(Get), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Создать запись
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<TDto>> Create(TCreateUpdateDto dto)
    {
        try
        {
            var created = await appService.Create(dto);
            logger.LogInformation("Created new item with id in {Controller}", GetType().Name);
            return CreatedAtAction(nameof(Create), created);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {Method} method of {Controller}", nameof(Create), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Обновить запись по идентификатору
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<TDto>> Update(TKey id, TCreateUpdateDto dto)
    {
        try
        {
            var updated = await appService.Update(dto, id);
            logger.LogInformation("Updated item {Id} in {Controller}", id, GetType().Name);
            return Ok(updated);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning(ex, "Updating item with ID {Id} not found in {Controller}", id, GetType().Name);
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {Method} method of {Controller}", nameof(Update), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Удалить запись по идентификатору
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> Delete(TKey id)
    {
        try
        {
            var result = await appService.Delete(id);
            logger.LogInformation("Deleted item {Id} in {Controller}", id, GetType().Name);
            return result ? Ok() : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {Method} method of {Controller}", nameof(Delete), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n{ex.InnerException?.Message}");
        }
    }
}