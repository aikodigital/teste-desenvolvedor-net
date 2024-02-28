using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Data.AutoMapperProfiles
{
    public class StopProfile : Profile
    {
        public StopProfile()
        {
            CreateMap<Stop, StopResponse>().ReverseMap();
            CreateMap<Stop, StopRequest>().ReverseMap();
            CreateMap<Stop, CreateStopRequest>().ReverseMap();
            CreateMap<Stop, UpdateStopRequest>().ReverseMap();
            CreateMap<Stop, DeleteStopRequest>().ReverseMap();
        }
    }
}
