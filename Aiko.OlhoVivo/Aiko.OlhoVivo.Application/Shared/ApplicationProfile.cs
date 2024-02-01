using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Infrastructure.Dto;
using AutoMapper;

namespace Aiko.OlhoVivo.Application.Shared;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Stop, StopModel>().ReverseMap();
        CreateMap<Vehicle, VehicleModel>().ReverseMap();
        CreateMap<LineStop, LineStopModel>().ReverseMap();
        CreateMap<VehiclePosition, VehiclePositionModel>().ReverseMap();
        CreateMap<Line, LineModel>().ReverseMap()
            .ForMember(dest => dest.Stop, o => o.MapFrom(src => src.LineStop
            .Where(x => x.Id == src.Id).Select(i => i.Stop)));

    }
}
