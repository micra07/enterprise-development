using AirCompany.Application.Contracts.Dtos.Tickets;
using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления билетами
/// Предоставляет CRUD-операции для сущности <see cref="TicketDto"/>
/// </summary>
/// <param name="service">Сервис приложения для работы с билетами</param>
/// <param name="logger">Логгер для записи действий и ошибок контроллера</param>
[Route("api/[controller]")]
[ApiController]
public class TicketController(IApplicationService<TicketDto, TicketCreateUpdateDto, int> service, ILogger<TicketController> logger)
    : CrudControllerBase<TicketDto, TicketCreateUpdateDto, int>(service, logger);