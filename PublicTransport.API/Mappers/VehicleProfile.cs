using AutoMapper;
using PublicTransport.API.Entities;
using PublicTransport.API.Models.Inputs;
using PublicTransport.API.Models.Views;

namespace PublicTransport.API.Mappers;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<Vehicle, VehicleViewModel>();

        CreateMap<VehicleInputModel, Vehicle>();
    }
}