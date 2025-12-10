using AirCompany.Application.Contracts.Dtos.Tickets;
using AirCompany.Generator.Nats.Host.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Generator.Nats.Host.Controllers;

/// <summary>
/// Контроллер генератора который по запросу формирует тестовые тикеты и отправляет их батчами через IProducerService
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GeneratorController(ILogger<GeneratorController> logger, IProducerService producerService) : ControllerBase
{
    /// <summary>
    /// Генерирует payloadLimit билетов порциями по batchSize с паузой waitTime секунд между отправками
    /// </summary>
    /// <param name="batchSize">Количество билетов в одной отправке</param>
    /// <param name="payloadLimit">Общее количество генерируемых билетов, которое требуется отправить суммарно</param>
    /// <param name="waitTime">Задержка между отправками батчей в секундах</param>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<TicketCreateUpdateDto>>> Get([FromQuery] int batchSize, [FromQuery] int payloadLimit, [FromQuery] int waitTime)
    {
        logger.LogInformation("Generating {limit} contracts via {batchSize} batches and {waitTime}s delay", payloadLimit, batchSize, waitTime);
        try
        {
            var list = new List<TicketCreateUpdateDto>(payloadLimit);
            var counter = 0;
            while (counter < payloadLimit)
            {
                var batch = TicketGenerator.GenerateContract(batchSize);
                await producerService.SendAsync(batch);
                logger.LogInformation("Batch of {batchSize} items has been sent", batchSize);

                counter += batchSize;
                list.AddRange(batch);
                await Task.Delay(waitTime * 1000);
            }
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(list);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(Get), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}