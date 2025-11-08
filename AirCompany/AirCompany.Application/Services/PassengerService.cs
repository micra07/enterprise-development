using AirCompany.Application.Contracts.Dtos.Passengers;
using AirCompany.Application.Contracts.Interfaces;
using AirCompany.Domain.Interfaces;
using AirCompany.Domain.Models;
using AutoMapper;

namespace AirCompany.Application.Services;

/// <summary>
/// Сервис для выполнения CRUD-операций с пассажирами
/// </summary>
/// <param name="repository">Репозиторий сущности</param>
/// <param name="mapper">Профиль маппинга</param>
public class PassengerService(IRepository<Passenger, int> repository, IMapper mapper) : IApplicationService<PassengerDto, PassengerCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<PassengerDto> Create(PassengerCreateUpdateDto dto)
    {
        var entity = mapper.Map<Passenger>(dto);

        var result = await repository.CreateAsync(entity);

        return mapper.Map<PassengerDto>(result);
    }

    //// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) => await repository.DeleteAsync(dtoId);

    /// <inheritdoc/>
    public async Task<PassengerDto?> Get(int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");
        return mapper.Map<PassengerDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<PassengerDto>> GetAll() => mapper.Map<List<PassengerDto>>(await repository.GetAllAsync());

    /// <inheritdoc/>
    public async Task<PassengerDto> Update(PassengerCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");

        mapper.Map(dto, entity);
        var result = repository.UpdateAsync(entity);

        return mapper.Map<PassengerDto>(result);
    }
}