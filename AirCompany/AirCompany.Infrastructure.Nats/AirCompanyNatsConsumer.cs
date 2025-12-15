using AirCompany.Application.Contracts.Dtos.Tickets;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Infrastructure.Nats.Deserializers;
using AirCompany.Infrastructure.Nats.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NATS.Client.Core;
using NATS.Client.JetStream.Models;
using NATS.Net;

namespace AirCompany.Infrastructure.Nats;

/// <summary>
/// Фоновая служба чтения сообщений из NATS JetStream через push consumer
/// Подключается к NATS, создаёт consumer для указанного stream и читает сообщения
/// Для каждого сообщения создаёт scope, получает сервис приложения и создаёт тикеты из списка DTO
/// </summary>
/// <param name="connection">Подключение к Nats</param>
/// <param name="scopeFactory">Фабрика контекста</param>
/// <param name="configuration">Конфигурация</param>
/// <param name="logger">Логгер</param>
public class AirCompanyNatsConsumer(
    INatsConnection connection,
    IServiceScopeFactory scopeFactory,
    IOptions<NatsOptions> options,
    ILogger<AirCompanyNatsConsumer> logger
) : BackgroundService
{
    /// <summary>
    /// Имя stream берётся из настроек
    /// </summary>
    private readonly string _streamName = options.Value.StreamName;

    /// <summary>
    /// Имя subject берётся из настроек
    /// </summary>
    private readonly string _subjectName = options.Value.SubjectName;

    /// <summary>
    /// Основной цикл работы службы
    /// Подключается к NATS, создаёт JetStream consumer и читает сообщения до остановки приложения
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await connection.ConnectAsync();

            var context = connection.CreateJetStreamContext();

            await context.CreateOrUpdateStreamAsync(new StreamConfig(_streamName, [_subjectName]), stoppingToken);

            logger.LogInformation("Creating consumer for a stream {stream} and subject {subject}", _streamName, _subjectName);

            var consumer = await context.CreateConsumerAsync(
                _streamName,
                new ConsumerConfig
                {
                    DeliverPolicy = ConsumerConfigDeliverPolicy.All,
                    AckPolicy = ConsumerConfigAckPolicy.Explicit
                },
                stoppingToken
            );

            await foreach (var message in consumer.ConsumeAsync(new TicketPayloadDeserializer(), cancellationToken: stoppingToken))
            {
                if (message.Data is null)
                    continue;

                using var scope = scopeFactory.CreateScope();
                var ticketService = scope.ServiceProvider.GetRequiredService<IApplicationService<TicketDto, TicketCreateUpdateDto, int>>();

                foreach (var ticket in message.Data)
                    await ticketService.Create(ticket);

                await message.AckAsync(cancellationToken: stoppingToken);

                logger.LogInformation("Successfully consumed message from subject {subject} of stream {stream}", _subjectName, _streamName);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Consumer failed to start stream={stream} subject={subject} message={message}",
                _streamName, _subjectName, ex.Message);
        }
    }
}