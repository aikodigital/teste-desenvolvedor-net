
using MediatR;

namespace TransportePublico.App.Queries.PosicoesVeiculos.GetById;

public class GetPosicaoVeiculoByIdQuery : IRequest<PosicaoVeiculoDto>
{
    public long Id { get; set; }
    public GetPosicaoVeiculoByIdQuery(long id)
    {
        Id = id;
    }
}