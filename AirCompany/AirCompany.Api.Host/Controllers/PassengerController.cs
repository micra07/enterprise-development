using AirCompany.Application.Contracts.Dtos.Passengers;
using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления пассажирами
/// Предоставляет CRUD-операции для сущности <see cref="PassengerDto"/>
/// </summary>
/// <param name="service">Сервис приложения для работы с пассажирами</param>
/// <param name="logger">Логгер для записи действий и ошибок контроллера</param>
[Route("api/[controller]")]
[ApiController]
public class PassengerController(IApplicationService<PassengerDto, PassengerCreateUpdateDto, int> service, ILogger<PassengerController> logger)
    : CrudControllerBase<PassengerDto, PassengerCreateUpdateDto, int>(service, logger);