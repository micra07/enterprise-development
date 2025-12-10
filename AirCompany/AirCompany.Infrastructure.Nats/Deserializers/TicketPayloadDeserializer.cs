using AirCompany.Application.Contracts.Dtos.Tickets;
using NATS.Client.Core;
using System.Buffers;
using System.Text.Json;

namespace AirCompany.Infrastructure.Nats.Deserializers;

/// <summary>
/// Десериализатор полезной нагрузки сообщения NATS
/// Преобразует входной буфер байт с JSON в список DTO для создания или обновления билетов
/// </summary>
public class TicketPayloadDeserializer : INatsDeserialize<IList<TicketCreateUpdateDto>>
{
    /// <summary>
    /// Читает буфер сообщения и выполняет десериализацию JSON в IList<TicketCreateUpdateDto>
    /// Возвращает null если десериализация не удалась или если данные отсутствуют
    /// </summary>
    public IList<TicketCreateUpdateDto>? Deserialize(in ReadOnlySequence<byte> buffer)
    {
        var reader = new Utf8JsonReader(buffer, isFinalBlock: true, state: default);
        return JsonSerializer.Deserialize<IList<TicketCreateUpdateDto>>(ref reader);
    }
}