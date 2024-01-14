
namespace TransportePublico.Domain.Entity
{
    public class PosicaoVeiculo
    {
        public double Latitude {get; set;}
        public double Longitude {get; set;}
        public long VeiculoId {get; set;}
        public Veiculo? Veiculo {get; set;}
    }
}