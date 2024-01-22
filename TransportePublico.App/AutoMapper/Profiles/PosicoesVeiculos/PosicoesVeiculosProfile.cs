using AutoMapper;
using TransportePublico.App.Commands.PosicoesVeiculos.Create;
using TransportePublico.App.Commands.PosicoesVeiculos.Update;
using TransportePublico.App.Queries.PosicoesVeiculos;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.AutoMapper.Profiles.PosicoesVeiculos
{
    public class PosicoesVeiculosProfile : Profile
    {
        public PosicoesVeiculosProfile()
        {
            CreateMap<PosicaoVeiculo, PosicaoVeiculoDto>();

            CreateMap<PosicaoVeiculo, UpdatePosicaoVeiculoDto>().ReverseMap();
            
            CreateMap<PosicaoVeiculo, NewPosicaoVeiculoDto>().ReverseMap();
        }
    }
}