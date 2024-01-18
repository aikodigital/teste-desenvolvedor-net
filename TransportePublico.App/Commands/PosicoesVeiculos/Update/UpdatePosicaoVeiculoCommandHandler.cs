using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Update;

public class UpdatePosicaoVeiculoCommandHandler : IRequestHandler<UpdatePosicaoVeiculoCommand, bool>
{
    private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;
    private readonly IMapper _mapper;

    public UpdatePosicaoVeiculoCommandHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository, 
        IMapper mapper)
    {
        _posicaoVeiculoRepository = posicaoVeiculoRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdatePosicaoVeiculoCommand request, CancellationToken cancellationToken)
    {
        var posicaoVeiculo = _mapper.Map<PosicaoVeiculo>(request.Dto);
        var statusOk = await _posicaoVeiculoRepository.Update(posicaoVeiculo);
        return statusOk;
    }
}