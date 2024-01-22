using AutoMapper;
using TransportePublico.App.Commands.Paradas.Create;
using TransportePublico.App.Commands.Paradas.Update;
using TransportePublico.App.Queries.Paradas;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.AutoMapper.Profiles.Paradas
{
    public class ParadasProfile : Profile
    {
        public ParadasProfile()
        {
            CreateMap<Parada, ParadaDto>();

            CreateMap<Parada, UpdateParadaDto>().ReverseMap();
            
            CreateMap<Parada, NewParadaDto>().ReverseMap();
        }
    }
}