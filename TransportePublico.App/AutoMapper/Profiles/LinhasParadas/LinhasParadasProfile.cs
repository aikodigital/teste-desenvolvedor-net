using AutoMapper;
using TransportePublico.App.Queries.LinhasParadas;
using TransportePublico.Domain.Entity.LinhasParadas;

namespace TransportePublico.App.AutoMapper.Profiles.LinhasParadas
{
    public class LinhasParadasProfile : Profile
    {
        public LinhasParadasProfile()
        {
            CreateMap<LinhaParada, LinhaParadaDto>();
                
        }
    }
}