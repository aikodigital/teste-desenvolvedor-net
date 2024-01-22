
using MediatR;

namespace TransportePublico.App.Queries.Veiculos.GetAll;

public class GetAllVeiculosQuery : IRequest<IEnumerable<VeiculoDto>>
{
    public GetAllVeiculosQuery()
    {
    }
}