using MediatR;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Delete;

public class DeletePosicaoVeiculoCommandHandler : IRequestHandler<DeletePosicaoVeiculoCommand, bool>
{
    private readonly IPosicaoVeiculoRepository _posicaoVeiculoRepository;

    public DeletePosicaoVeiculoCommandHandler(IPosicaoVeiculoRepository posicaoVeiculoRepository)
    {
        _posicaoVeiculoRepository = posicaoVeiculoRepository;
    }

    public async Task<bool> Handle(DeletePosicaoVeiculoCommand request, CancellationToken cancellationToken)
    {
        var posicaoVeiculo = await _posicaoVeiculoRepository.GetById(request.Id);
        var statusOk = await _posicaoVeiculoRepository.Remove(posicaoVeiculo);
        return statusOk;
    }
}