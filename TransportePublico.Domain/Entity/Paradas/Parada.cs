
namespace TransportePublico.Domain.Entity.Paradas
{
    public class Parada
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}