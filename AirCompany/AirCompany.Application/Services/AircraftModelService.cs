using AirCompany.Application.Contracts.Dtos.AircraftModels;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using AutoMapper;

namespace AirCompany.Application.Services;

/// <summary>
/// Сервис для выполнения CRUD-операций с моделями самолётов
/// </summary>
/// <param name="repository">Репозиторий сущности</param>
/// <param name="mapper">Профиль маппинга</param>
public class AircraftModelService(IRepository<AircraftModel, int> repository, IMapper mapper) : IApplicationService<AircraftModelDto, AircraftModelCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<AircraftModelDto> Create(AircraftModelCreateUpdateDto dto)
    {
        var entity = mapper.Map<AircraftModel>(dto);

        var result = await repository.CreateAsync(entity);

        return mapper.Map<AircraftModelDto>(result);
    }

    //// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) => await repository.DeleteAsync(dtoId);

    /// <inheritdoc/>
    public async Task<AircraftModelDto?> Get(int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");
        return mapper.Map<AircraftModelDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<AircraftModelDto>> GetAll() => mapper.Map<List<AircraftModelDto>>(await repository.GetAllAsync());

    /// <inheritdoc/>
    public async Task<AircraftModelDto> Update(AircraftModelCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");

        mapper.Map(dto, entity);
        var result = await repository.UpdateAsync(entity);

        return mapper.Map<AircraftModelDto>(result);
    }
}