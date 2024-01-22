
using MediatR;

namespace TransportePublico.App.Queries.Paradas.GetById;

public class GetParadaByIdQuery : IRequest<ParadaDto>
{
    public long Id { get; set; }
    public GetParadaByIdQuery(long id)
    {
        Id = id;
    }
}