
using MediatR;
using TransportePublico.App.Queries.Linhas;

namespace TransportePublico.App.Queries.LinhasParadas.GetLinhasByParada;

public class GetLinhasByParadaQuery : IRequest<IEnumerable<LinhaDto>>
{
    public long ParadaId { get; set; }
    public GetLinhasByParadaQuery(long paradaId)
    {
        ParadaId = paradaId;
    }
}