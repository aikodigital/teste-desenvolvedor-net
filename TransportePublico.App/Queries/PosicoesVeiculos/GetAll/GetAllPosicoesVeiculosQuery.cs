
using MediatR;

namespace TransportePublico.App.Queries.PosicoesVeiculos.GetAll;

public class GetAllPosicoesVeiculosQuery : IRequest<IEnumerable<PosicaoVeiculoDto>>
{
    public GetAllPosicoesVeiculosQuery()
    {
    }
}