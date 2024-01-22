using MediatR;
using TransportePublico.Domain.Entity.LinhasParadas;

namespace TransportePublico.App.Commands.LinhasParadas.Disassociate;

public class DisassociateLinhasParadasCommandHandler : IRequestHandler<DisassociateLinhasParadasCommand, bool>
{
    private readonly ILinhaParadaRepository _linhaParadaRepository;

    public DisassociateLinhasParadasCommandHandler(ILinhaParadaRepository linhaParadaRepository)
    {
        _linhaParadaRepository = linhaParadaRepository;
    }

    public async Task<bool> Handle(DisassociateLinhasParadasCommand request, CancellationToken cancellationToken)
    {
        var linhaParada = new LinhaParada(request.LinhaId, request.ParadaId);
        var statusOk = await _linhaParadaRepository.Disassociate(linhaParada);
        return statusOk;
    }
}