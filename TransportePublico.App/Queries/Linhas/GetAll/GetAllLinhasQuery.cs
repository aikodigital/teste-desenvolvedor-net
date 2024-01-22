
using MediatR;

namespace TransportePublico.App.Queries.Linhas.GetAll;

public class GetAllLinhasQuery : IRequest<IEnumerable<LinhaDto>>
{
    public GetAllLinhasQuery()
    {
    }
}