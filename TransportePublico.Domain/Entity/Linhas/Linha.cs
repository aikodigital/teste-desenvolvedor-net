
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.Domain.Entity.Linhas
{
    public class Linha
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Parada>? Paradas {get; set;}
    }
}