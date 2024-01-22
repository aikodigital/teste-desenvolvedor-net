using MediatR;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.Commands.Paradas.Delete;

public class DeleteParadaCommandHandler : IRequestHandler<DeleteParadaCommand, bool>
{
    private readonly IParadaRepository _paradaRepository;

    public DeleteParadaCommandHandler(IParadaRepository paradaRepository)
    {
        _paradaRepository = paradaRepository;
    }

    public async Task<bool> Handle(DeleteParadaCommand request, CancellationToken cancellationToken)
    {
        var parada = await _paradaRepository.GetById(request.Id);
        var statusOk = await _paradaRepository.Remove(parada);
        return statusOk;
    }
}