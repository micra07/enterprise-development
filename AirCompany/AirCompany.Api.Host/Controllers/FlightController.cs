using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления рейсами
/// Предоставляет CRUD-операции для сущности <see cref="FlightDto"/>
/// </summary>
/// <param name="service">Сервис приложения для работы с рейсами</param>
/// <param name="logger">Логгер для записи действий и ошибок контроллера</param>
[Route("api/[controller]")]
[ApiController]
public class FlightController(IApplicationService<FlightDto, FlightCreateUpdateDto, int> service, ILogger<FlightController> logger)
    : CrudControllerBase<FlightDto, FlightCreateUpdateDto, int>(service, logger);