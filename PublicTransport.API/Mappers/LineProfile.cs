using PublicTransport.API.Entities;
using PublicTransport.API.Models.Views;
using AutoMapper;
using PublicTransport.API.Models.Inputs;

namespace PublicTransport.API.Mappers;

public class LineProfile : Profile
{
    public LineProfile()
    {
        CreateMap<Line, LineViewModel>();

        CreateMap<LineInputModel, Line>(); 
    }
}