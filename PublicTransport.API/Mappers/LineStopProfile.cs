using AutoMapper;
using PublicTransport.API.Models.Views;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;

namespace PublicTransport.API.Mappers;

public class LineStopProfile : Profile
{
    public LineStopProfile()
    {
        CreateMap<LineStopInputModel, LineStop>();

        CreateMap<LineStop, LineStopViewModel>();
    }
}