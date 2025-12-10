using AirCompany.Application.Contracts.Dtos.Tickets;

namespace AirCompany.Generator.Nats.Host.Interfaces;

/// <summary>
/// Контракт сервиса отправки сообщений
/// Принимает батч DTO тикетов и отправляет его асинхронно в транспорт
/// </summary>
public interface IProducerService
{
    /// <summary>
    /// Отправляет батч TicketCreateUpdateDto
    /// </summary>
    public Task SendAsync(IList<TicketCreateUpdateDto> batch);
}