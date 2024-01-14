using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Queries.PosicoesVeiculos.GetById;

public class GetPosicaoVeiculoByIdQueryHandler : IRequestHandler<GetPosicaoVeiculoByIdQuery, PosicaoVeiculoDto>
{
    private readonly IMapper _mapper;
    private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;

    public GetPosicaoVeiculoByIdQueryHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _posicaoVeiculoRepository = posicaoVeiculoRepository;
    }
    

    public async Task<PosicaoVeiculoDto> Handle(GetPosicaoVeiculoByIdQuery request,
        CancellationToken cancellationToken)
    {
        var posicaoVeiculo = await _posicaoVeiculoRepository.GetById(request.Id);
        return _mapper.Map<PosicaoVeiculoDto>(posicaoVeiculo);
    }
}