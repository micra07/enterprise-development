using AirCompany.Application.Contracts.Dtos.AircraftFamilies;
using AirCompany.Application.Contracts.Dtos.AircraftModels;
using AirCompany.Application.Contracts.Dtos.Flights;
using AirCompany.Application.Contracts.Dtos.Passengers;
using AirCompany.Application.Contracts.Dtos.Tickets;
using AirCompany.Domain.Models;
using AutoMapper;

namespace AirCompany.Application.Mapper;

public class AirCompanyMapProfile : Profile
{
    public AirCompanyMapProfile()
    {
        CreateMap<AircraftFamily, AircraftFamilyDto>();
        CreateMap<AircraftFamily, AircraftFamilyDto>();

        CreateMap<AircraftModel, AircraftModelDto>();
        CreateMap<AircraftModelCreateUpdateDto, AircraftModel>();

        CreateMap<Flight, FlightDto>();
        CreateMap<FlightCreateUpdateDto, Flight>();

        CreateMap<Passenger, PassengerDto>();
        CreateMap<PassengerCreateUpdateDto, Passenger>();

        CreateMap<Ticket, TicketDto>();
        CreateMap<TicketCreateUpdateDto, Ticket>();
    }
}
