using TransportePublico.App.Queries.LinhasParadas;

namespace TransportePublico.App.Queries.Paradas
{
    public class ParadaDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual IEnumerable<LinhaParadaDto>? LinhasParadas { get; set; }
    }
}