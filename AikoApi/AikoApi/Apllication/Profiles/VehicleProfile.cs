using AikoApi.Apllication.Dtos;
using AikoApi.Models;
using AutoMapper;

namespace AikoApi.Apllication.Profiles;

    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>();
        }
    }
