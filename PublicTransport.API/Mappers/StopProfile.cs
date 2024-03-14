using AutoMapper;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;

namespace PublicTransport.API.Mappers;

public class StopProfile : Profile
{
    public StopProfile()
    {
        CreateMap<Stop, StopViewModel>();

        CreateMap<StopInputModel, Stop>();
    }

}