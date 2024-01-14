
namespace TransportePublico.Domain.Entity
{
    public class Linha
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Parada>? Paradas {get; set;}
    }
}