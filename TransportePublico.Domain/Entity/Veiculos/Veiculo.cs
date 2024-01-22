using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.Domain.Entity.Veiculos
{
    public class Veiculo
    {
        public long VeiculoId { get; set; }
        public string? Name { get; set; }
        public string? Modelo { get; set; }
        public long LinhaId { get; set; }
        public virtual Linha? Linha { get; set; }
    }
}