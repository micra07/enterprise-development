using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using AutoMapper;

namespace AirCompany.Application.Services;

/// <summary>
/// Сервис для выполнения CRUD-операций с рейсами
/// </summary>
/// <param name="repository">Репозиторий сущности</param>
/// <param name="mapper">Профиль маппинга</param>
public class FlightService(IRepository<Flight, int> repository, IMapper mapper) : IApplicationService<FlightDto, FlightCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<FlightDto> Create(FlightCreateUpdateDto dto)
    {
        var entity = mapper.Map<Flight>(dto);

        var result = await repository.CreateAsync(entity);

        return mapper.Map<FlightDto>(result);
    }

    //// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) => await repository.DeleteAsync(dtoId);

    /// <inheritdoc/>
    public async Task<FlightDto?> Get(int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");
        return mapper.Map<FlightDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<FlightDto>> GetAll() => mapper.Map<List<FlightDto>>(await repository.GetAllAsync());

    /// <inheritdoc/>
    public async Task<FlightDto> Update(FlightCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");

        mapper.Map(dto, entity);
        var result = await repository.UpdateAsync(entity);

        return mapper.Map<FlightDto>(result);
    }
}