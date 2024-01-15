
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.Domain.Entity.Paradas
{
    public class Parada
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long LinhaId { get; set; }
        public Linha? Linha { get; set; }
    }
}