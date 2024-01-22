using AutoMapper;
using TransportePublico.App.Commands.Linhas.Create;
using TransportePublico.App.Commands.Linhas.Update;
using TransportePublico.App.Queries.Linhas;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.AutoMapper.Profiles.Linhas
{
    public class LinhasProfile : Profile
    {
        public LinhasProfile()
        {
            CreateMap<Linha, LinhaDto>()
                .ForMember(dest => dest.LinhaId, opt => opt.MapFrom(src => src.LinhaId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Paradas, opt => opt.MapFrom(src => src.LinhasParadas.Where(p => p.LinhaId == src.LinhaId).Select(p => p.Parada)));

            CreateMap<Linha, UpdateLinhaDto>().ReverseMap();
            
            CreateMap<Linha, NewLinhaDto>().ReverseMap();
        }
    }
}