using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Update
{
    public class UpdatePosicaoVeiculoDto 
    {
    public long PosicaoVeiculoId {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public long VeiculoId {get; set;}
    }
}