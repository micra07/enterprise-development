using AirCompany.Application.Contracts.Dtos.AircraftFamilies;
using AirCompany.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.Api.Host.Controllers;

/// <summary>
/// Контроллер для управления семействами самолетов
/// Предоставляет CRUD-операции для сущности <see cref="AircraftFamilyDto"/>
/// </summary>
/// <param name="service">Сервис приложения для работы с семействами самолетов</param>
/// <param name="logger">Логгер для записи действий и ошибок контроллера</param>
[Route("api/[controller]")]
[ApiController]
public class AircraftFamilyController(IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int> service, ILogger<AircraftFamilyController> logger)
    : CrudControllerBase<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>(service, logger);