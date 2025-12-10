using AirCompany.Application.Contracts.Dtos.Tickets;
using AirCompany.Generator.Nats.Host.Interfaces;
using NATS.Client.Core;
using NATS.Client.JetStream.Models;
using NATS.Net;
using System.Text.Json;

namespace AirCompany.Generator.Nats.Host;

/// <summary>
/// Продюсер для отправки батчей TicketCreateUpdateDto в NATS JetStream
/// Берёт StreamName и SubjectName из конфигурации
/// При вызове SendAsync подключается к NATS, гарантирует наличие stream для subject и публикует батч в subject в формате JSON
/// </summary>
public class AirCompanyNatsProducer(
    IConfiguration configuration,
    INatsConnection connection,
    ILogger<AirCompanyNatsProducer> logger
) : IProducerService
{
    /// <summary>
    /// Имя stream берётся из конфигурации Nats:StreamName
    /// </summary>
    private readonly string _streamName = configuration.GetSection("Nats")["StreamName"] ?? throw new KeyNotFoundException("StreamName section of Nats is missing");

    /// <summary>
    /// Имя subject берётся из конфигурации Nats:SubjectName
    /// </summary>
    private readonly string _subjectName = configuration.GetSection("Nats")["SubjectName"] ?? throw new KeyNotFoundException("SubjectName section of Nats is missing");

    /// <inheritdoc/>
    public async Task SendAsync(IList<TicketCreateUpdateDto> batch)
    {
        try
        {
            await connection.ConnectAsync();

            var context = connection.CreateJetStreamContext();

            await context.CreateOrUpdateStreamAsync(new StreamConfig(_streamName, [_subjectName]));
            logger.LogInformation("Stream {stream} is ensured for subject {subject}", _streamName, _subjectName);

            await context.PublishAsync(_subjectName, JsonSerializer.SerializeToUtf8Bytes(batch));
            logger.LogInformation("Batch of {count} contracts published to {stream}/{subject}", batch.Count, _streamName, _subjectName);
        }
        catch (Exception ex) 
        {
            logger.LogError(ex, "Exception occured during sending a batch of {count} contracts to {stream}/{subject}", batch.Count, _streamName, _subjectName);
        }
    }
}