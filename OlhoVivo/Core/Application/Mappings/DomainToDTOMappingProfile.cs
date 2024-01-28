using AutoMapper;
using OlhoVivo.Core.Application.DTOs;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Stop, StopDTO>().ReverseMap();
        CreateMap<Line, LineDTO>().ReverseMap();
        CreateMap<Vehicle, VehicleDTO>().ReverseMap();
        CreateMap<VehiclePosition, VehiclePositionDTO>().ReverseMap();
    }

}
