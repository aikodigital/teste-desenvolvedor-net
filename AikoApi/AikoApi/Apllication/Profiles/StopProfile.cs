using AikoApi.Apllication.Dtos;
using AikoApi.Models;
using AutoMapper;

namespace AikoApi.Apllication.Profiles;

    public class StopProfile : Profile
    {
        public StopProfile()
        {
            CreateMap<StopDto, Stop>();
        }
    }
