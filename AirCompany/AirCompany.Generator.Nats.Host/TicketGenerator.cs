using AirCompany.Application.Contracts.Dtos.Tickets;
using Bogus;

namespace AirCompany.Generator.Nats.Host;

/// <summary>
/// Генератор тестовых контрактов для тикетов с использованием Bogus
/// </summary>
public static class TicketGenerator
{
    /// <summary>
    /// Генерирует список TicketCreateUpdateDto заданного размера
    /// Заполняет поля случайными значениями в заданных диапазонах
    /// </summary>
    public static IList<TicketCreateUpdateDto> GenerateContract(int count) =>
        new Faker<TicketCreateUpdateDto>()
            .CustomInstantiator(f => new TicketCreateUpdateDto(
                f.Random.Number(1, 50) + f.Random.String2(1, "ABCDEFG"),
                f.Random.Bool(),
                f.Random.Double(0, 25),
                f.Random.Int(1, 10),
                f.Random.Int(1, 20)
            ))
            .Generate(count);
}