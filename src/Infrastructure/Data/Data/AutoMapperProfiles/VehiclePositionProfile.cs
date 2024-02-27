using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Data.AutoMapperProfiles
{
    public class VehiclePositionProfile : Profile
    {
        public VehiclePositionProfile()
        {
            CreateMap<VehiclePosition, VehiclePositionResponse>().ReverseMap();
            CreateMap<VehiclePosition, VehiclePositionRequest>().ReverseMap();
            CreateMap<VehiclePosition, CreateVehiclePositionRequest>().ReverseMap();
            CreateMap<VehiclePosition, UpdateVehiclePositionRequest>().ReverseMap();
            CreateMap<VehiclePosition, DeleteVehiclePositionRequest>().ReverseMap();

        }
    }
}
