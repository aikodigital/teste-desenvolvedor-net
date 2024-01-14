
using MediatR;

namespace TransportePublico.App.Queries.Linhas.GetById;

public class GetLinhaByIdQuery : IRequest<LinhaDto>
{
    public long Id { get; set; }
    public GetLinhaByIdQuery(long id)
    {
        Id = id;
    }
}