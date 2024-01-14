
using MediatR;

namespace TransportePublico.App.Queries.Linhas.GetById;

public class GetLinhasByIdQuery : IRequest<LinhaDto>
{
    public long Id { get; set; }
    public GetLinhasByIdQuery(long id)
    {
        Id = id;
    }
}