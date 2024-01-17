using AikoApi.Apllication.Dtos;
using AikoApi.Models;
using AutoMapper;

namespace AikoApi.Apllication.Profiles;

    public class LineStopProfile : Profile
    {
        public LineStopProfile()
        {
            CreateMap<LineStopDto, LineStop>();
        }
    }
