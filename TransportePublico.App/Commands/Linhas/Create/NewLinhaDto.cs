using TransportePublico.App.Queries.Paradas;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Commands.Linhas.Create
{
    [AutoMapper.AutoMap(typeof(Linha), ReverseMap = true)]
    public class NewLinhaDto 
    {
    public string? Name { get; set; }
    public IEnumerable<ParadaDto>? Paradas {get; set;}
    }
}