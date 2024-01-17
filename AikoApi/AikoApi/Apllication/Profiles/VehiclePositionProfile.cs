using AikoApi.Apllication.Dtos;
using AikoApi.Models;
using AutoMapper;

namespace AikoApi.Apllication.Profiles;

    public class VehiclePositionProfile : Profile
    {
        public VehiclePositionProfile()
        {
            CreateMap<VehiclePositionDto, VehiclePosition>();
        }
    }
