using MediatR;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Commands.Veiculos.Delete;

public class DeleteVeiculoCommandHandler : IRequestHandler<DeleteVeiculoCommand, bool>
{
    private readonly IVeiculoRepository _veiculoRepository;

    public DeleteVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<bool> Handle(DeleteVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.GetById(request.Id);
        var statusOk = await _veiculoRepository.Remove(veiculo);
        return statusOk;
    }
}