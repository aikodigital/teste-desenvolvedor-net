using AutoMapper;
using TransportePublico.App.Commands.Veiculos.Create;
using TransportePublico.App.Commands.Veiculos.Update;
using TransportePublico.App.Queries.Veiculos;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.AutoMapper.Profiles.Veiculos
{
    public class VeiculosProfile : Profile
    {
        public VeiculosProfile()
        {
            CreateMap<Veiculo, VeiculoDto>();

            CreateMap<Veiculo, UpdateVeiculoDto>().ReverseMap();
            
            CreateMap<Veiculo, NewVeiculoDto>().ReverseMap();
        }
    }
}