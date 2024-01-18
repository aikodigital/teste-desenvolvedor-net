using MediatR;
using TransportePublico.Domain.Entity.LinhasParadas;

namespace TransportePublico.App.Commands.LinhasParadas.Associate;

public class AssociateLinhasParadasCommandHandler : IRequestHandler<AssociateLinhasParadasCommand, bool>
{
    private readonly ILinhaParadaRepository _linhaParadaRepository;

    public AssociateLinhasParadasCommandHandler(ILinhaParadaRepository linhaParadaRepository)
    {
        _linhaParadaRepository = linhaParadaRepository;
    }

    public async Task<bool> Handle(AssociateLinhasParadasCommand request, CancellationToken cancellationToken)
    {
        var linhaParada = new LinhaParada(request.LinhaId, request.ParadaId);
        var statusOk = await _linhaParadaRepository.Associate(linhaParada);
        return statusOk;
    }
}