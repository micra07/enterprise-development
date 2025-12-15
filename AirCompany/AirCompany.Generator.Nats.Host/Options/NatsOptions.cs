namespace AirCompany.Generator.Nats.Host.Options;

/// <summary>
/// Типизированные настройки NATS
/// Хранит параметры StreamName и SubjectName которые используются продюсером и консьюмером
/// Привязывается к секции конфигурации Nats и валидируется при старте приложения
/// </summary>
public sealed class NatsOptions
{
    /// <summary>
    /// Имя секции конфигурации для привязки настроек
    /// </summary>
    public const string SectionName = "Nats";

    /// <summary>
    /// Имя JetStream stream в который публикуются и из которого читаются сообщения
    /// </summary>
    public required string StreamName { get; init; }

    /// <summary>
    /// Имя subject по которому публикуются сообщения и который используется при настройке stream
    /// </summary>
    public required string SubjectName { get; init; }
}