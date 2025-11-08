using AirCompany.Application.Contracts.Dtos.AircraftFamilies;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using AutoMapper;

namespace AirCompany.Application.Services;

/// <summary>
/// Сервис для выполнения CRUD-операций с билетами
/// </summary>
/// <param name="repository">Репозиторий сущности</param>
/// <param name="mapper">Профиль маппинга</param>
public class AircraftFamilyService(IRepository<AircraftFamily, int> repository, IMapper mapper) : IApplicationService<AircraftFamilyDto, AircraftFamilyCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<AircraftFamilyDto> Create(AircraftFamilyCreateUpdateDto dto)
    {
        var entity = mapper.Map<AircraftFamily>(dto);

        var result = await repository.CreateAsync(entity);

        return mapper.Map<AircraftFamilyDto>(result);
    }

    //// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) => await repository.DeleteAsync(dtoId);

    /// <inheritdoc/>
    public async Task<AircraftFamilyDto?> Get(int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");
        return mapper.Map<AircraftFamilyDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<AircraftFamilyDto>> GetAll() => mapper.Map<List<AircraftFamilyDto>>(await repository.GetAllAsync());

    /// <inheritdoc/>
    public async Task<AircraftFamilyDto> Update(AircraftFamilyCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");

        mapper.Map(dto, entity);
        var result = repository.UpdateAsync(entity);

        return mapper.Map<AircraftFamilyDto>(result);
    }
}