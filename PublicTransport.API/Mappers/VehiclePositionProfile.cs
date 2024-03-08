using AutoMapper;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;

namespace PublicTransport.API.Mappers;

public class VehiclePositionProfile : Profile
{
    public VehiclePositionProfile()
    {
        CreateMap<VehiclePosition, VehiclePositionViewModel>();

        CreateMap<VehiclePositionInputModel, VehiclePosition>();
    }
}