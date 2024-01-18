
using MediatR;

namespace TransportePublico.App.Queries.Veiculos.GetById;

public class GetVeiculoByIdQuery : IRequest<VeiculoDto>
{
    public long Id { get; set; }
    public GetVeiculoByIdQuery(long id)
    {
        Id = id;
    }
}