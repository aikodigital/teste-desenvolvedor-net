using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Data.AutoMapperProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleResponse>().ReverseMap();
            CreateMap<Vehicle, VehicleRequest>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleRequest>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleRequest>().ReverseMap();
            CreateMap<Vehicle, DeleteVehicleRequest>().ReverseMap();
        }
    }
}
