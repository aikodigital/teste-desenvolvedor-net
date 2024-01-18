using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Commands.Veiculos.Update
{
    public class UpdateVeiculoDto 
    {
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Modelo { get; set; }
    public long LinhaId { get; set; }
    }
}