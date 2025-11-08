using AirCompany.Application.Contracts.Dtos.AircraftModels;
using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления моделями самолетов
/// Предоставляет CRUD-операции для сущности <see cref="AircraftModelDto"/>
/// </summary>
/// <param name="service">Сервис приложения для работы с моделями самолетов</param>
/// <param name="logger">Логгер для записи действий и ошибок контроллера</param>
[Route("api/[controller]")]
[ApiController]
public class AircraftModelController(IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int> service, ILogger<AircraftModelController> logger)
    : CrudControllerBase<AircraftModelDto, AircraftModelCreateUpdateDto, int>(service, logger);