using TransportePublico.App.Queries.LinhasParadas;
using TransportePublico.App.Queries.Paradas;
using TransportePublico.App.Queries.Veiculos;
namespace TransportePublico.App.Queries.Linhas
{
    public class LinhaDto
    {
        public long LinhaId { get; set; }
        public string? Name { get; set; }
        public virtual IEnumerable<LinhaParadaDto>? LinhasParadas {get; set;}
        public virtual IEnumerable<ParadaDto>? Paradas {get; set;}
        public virtual IEnumerable<VeiculoDto>? Veiculos {get; set;}
    }
}