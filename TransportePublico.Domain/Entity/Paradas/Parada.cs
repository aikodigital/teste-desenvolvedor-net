
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Domain.Entity.LinhasParadas;
#nullable disable
namespace TransportePublico.Domain.Entity.Paradas
{
    public class Parada
    {
        public long ParadaId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual IEnumerable<LinhaParada> LinhasParadas { get; set; }
        public virtual IEnumerable<Linha> Linhas { get; set; }
    }
}