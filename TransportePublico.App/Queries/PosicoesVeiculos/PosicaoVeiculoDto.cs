using TransportePublico.App.Queries.Veiculos;

namespace TransportePublico.App.Queries.PosicoesVeiculos
{
    public class PosicaoVeiculoDto
    {
        public long PosicaoVeiculoId {get; set;}
        public double Latitude {get; set;}
        public double Longitude {get; set;}
        public long VeiculoId {get; set;}
        public VeiculoDto? Veiculo {get; set;}
    }
}