using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;

namespace Data.AutoMapperProfiles
{
    public class LineProfile : Profile
    {
        public LineProfile()
        {
            CreateMap<Line, LineResponse>().ReverseMap();
            CreateMap<Line, LineRequest>().ReverseMap();
            CreateMap<Line, CreateLineRequest>().ReverseMap();
            CreateMap<Line, UpdateLineRequest>().ReverseMap();
            CreateMap<Line, DeleteLineRequest>().ReverseMap();
        }
    }
}
