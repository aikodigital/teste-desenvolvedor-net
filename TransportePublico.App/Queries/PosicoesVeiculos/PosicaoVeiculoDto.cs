using TransportePublico.App.Queries.Veiculos;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Queries.PosicoesVeiculos
{
    [AutoMapper.AutoMap(typeof(PosicaoVeiculo), ReverseMap = true)]
    public class PosicaoVeiculoDto
    {
        public double Latitude {get; set;}
        public double Longitude {get; set;}
        public long VeiculoId {get; set;}
        public VeiculoDto? Veiculo {get; set;}
    }
}