using AirCompany.Application.Contracts.Dtos.Tickets;
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
public class TicketService(IRepository<Ticket, int> repository, IMapper mapper) : IApplicationService<TicketDto, TicketCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<TicketDto> Create(TicketCreateUpdateDto dto)
    {
        var entity = mapper.Map<Ticket>(dto);

        var result = await repository.CreateAsync(entity);

        return mapper.Map<TicketDto>(result);
    }

    //// <inheritdoc/>
    public async Task<bool> Delete(int dtoId) => await repository.DeleteAsync(dtoId);

    /// <inheritdoc/>
    public async Task<TicketDto?> Get(int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");
        return mapper.Map<TicketDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<IList<TicketDto>> GetAll() => mapper.Map<List<TicketDto>>(await repository.GetAllAsync());

    /// <inheritdoc/>
    public async Task<TicketDto> Update(TicketCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.GetAsync(dtoId) ?? throw new KeyNotFoundException($"Entity with ID: {dtoId} not found");

        mapper.Map(dto, entity);
        var result = repository.UpdateAsync(entity);

        return mapper.Map<TicketDto>(result);
    }
}