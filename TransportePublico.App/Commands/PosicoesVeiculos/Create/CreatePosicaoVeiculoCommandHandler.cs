using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Create;

public class CreatePosicaoVeiculoCommandHandler : IRequestHandler<CreatePosicaoVeiculoCommand, bool>
{
    private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;
    private readonly IMapper _mapper;

    public CreatePosicaoVeiculoCommandHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository, 
        IMapper mapper)
    {
        _posicaoVeiculoRepository = posicaoVeiculoRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreatePosicaoVeiculoCommand request, CancellationToken cancellationToken)
    {
        var posicaoVeiculo = _mapper.Map<PosicaoVeiculo>(request.Dto);
        var statusOk = await _posicaoVeiculoRepository.Add(posicaoVeiculo);
        return statusOk;
    }
}