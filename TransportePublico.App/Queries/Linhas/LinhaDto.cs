using TransportePublico.App.Queries.Paradas;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Queries.Linhas
{
    [AutoMapper.AutoMap(typeof(Linha), ReverseMap = true)]
    public class LinhaDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<ParadaDto>? Paradas {get; set;}
    }
}