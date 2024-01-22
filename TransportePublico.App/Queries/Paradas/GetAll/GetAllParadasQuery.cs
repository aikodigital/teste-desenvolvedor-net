
using MediatR;

namespace TransportePublico.App.Queries.Paradas.GetAll;

public class GetAllParadasQuery : IRequest<IEnumerable<ParadaDto>>
{
    public GetAllParadasQuery()
    {
    }
}