using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.Queries.Paradas
{
    [AutoMapper.AutoMap(typeof(Parada), ReverseMap = true)]
    public class ParadaDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}