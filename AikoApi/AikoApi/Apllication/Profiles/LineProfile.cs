using AikoApi.Apllication.Dtos;
using AikoApi.Models;
using AutoMapper;

namespace AikoApi.Apllication.Profiles;

    public class LineProfile : Profile
    {
        public LineProfile()
        {
            CreateMap<LineDto, Line>();
        }
    }
