using TransportePublico.Domain.Entity.LinhasParadas;
using TransportePublico.Domain.Entity.Paradas;
using TransportePublico.Domain.Entity.Veiculos;
#nullable disable
namespace TransportePublico.Domain.Entity.Linhas
{
    public class Linha
    {
        public long LinhaId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<LinhaParada> LinhasParadas {get; set;}
        public virtual IEnumerable<Parada> Paradas {get; set;}
    }
}