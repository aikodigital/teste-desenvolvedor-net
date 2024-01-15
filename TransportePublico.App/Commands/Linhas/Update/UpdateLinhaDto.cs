using TransportePublico.App.Queries.Paradas;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Commands.Linhas.Update
{
    [AutoMapper.AutoMap(typeof(Linha), ReverseMap = true)]
    public class UpdateLinhaDto 
    {
    public long Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<ParadaDto>? Paradas {get; set;}
    }
}