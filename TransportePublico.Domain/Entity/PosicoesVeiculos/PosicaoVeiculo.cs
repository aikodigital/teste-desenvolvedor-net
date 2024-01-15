
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.Domain.Entity.PosicoesVeiculos
{
    public class PosicaoVeiculo
    {
        public long PosicaoVeiculoId {get; set;}
        public double Latitude {get; set;}
        public double Longitude {get; set;}
        public long VeiculoId {get; set;}
        public Veiculo? Veiculo {get; set;}
    }
}