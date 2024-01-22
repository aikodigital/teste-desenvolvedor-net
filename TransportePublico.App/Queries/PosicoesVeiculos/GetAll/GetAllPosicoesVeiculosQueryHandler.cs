using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Queries.PosicoesVeiculos.GetAll;

public class GetAllPosicoesVeiculosQueryHandler : IRequestHandler<GetAllPosicoesVeiculosQuery, IEnumerable<PosicaoVeiculoDto>>
{
    private readonly IMapper _mapper;
    private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;

    public GetAllPosicoesVeiculosQueryHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _posicaoVeiculoRepository = posicaoVeiculoRepository;
    }
    

    public async Task<IEnumerable<PosicaoVeiculoDto>> Handle(GetAllPosicoesVeiculosQuery request,
        CancellationToken cancellationToken)
    {
        var posicoesVeiculos = await _posicaoVeiculoRepository.GetAll();
        return _mapper.Map<IEnumerable<PosicaoVeiculoDto>>(posicoesVeiculos);
    }
}