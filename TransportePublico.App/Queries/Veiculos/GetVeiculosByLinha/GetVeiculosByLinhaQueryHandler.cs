using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Queries.Veiculos.GetVeiculosByLinha;

public class GetVeiculosByLinhaQueryHandler : IRequestHandler<GetVeiculosByLinhaQuery, IEnumerable<VeiculoDto>>
{
    private readonly IMapper _mapper;
    private readonly IVeiculoRepository _veiculoRepository;

    public GetVeiculosByLinhaQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _veiculoRepository = veiculoRepository;
    }

    public async Task<IEnumerable<VeiculoDto>> Handle(GetVeiculosByLinhaQuery request,
        CancellationToken cancellationToken)
    {
        var veiculos = await _veiculoRepository.GetVeiculosByLinha(request.LinhaId);
        return _mapper.Map<IEnumerable<VeiculoDto>>(veiculos);
    }
}