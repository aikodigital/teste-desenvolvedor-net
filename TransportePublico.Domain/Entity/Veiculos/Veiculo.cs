
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.Domain.Entity.Veiculos
{
    public class Veiculo
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Modelo { get; set; }
        public long LinhaId { get; set; }
        public Linha? Linha { get; set; }
    }
}