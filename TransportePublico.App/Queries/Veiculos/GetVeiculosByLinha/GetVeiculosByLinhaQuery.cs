
using MediatR;

namespace TransportePublico.App.Queries.Veiculos.GetVeiculosByLinha;

public class GetVeiculosByLinhaQuery : IRequest<IEnumerable<VeiculoDto>>
{
    public long LinhaId { get; set; }
    public GetVeiculosByLinhaQuery(long linhaId)
    {
        LinhaId = linhaId;
    }
}