using MediatR;

namespace TransportePublico.App.Commands.LinhasParadas.Disassociate;
public class DisassociateLinhasParadasCommand : IRequest<bool>
{
    public DisassociateLinhasParadasCommand(long linhaId, long paradaId)
    {
        LinhaId = linhaId;
        ParadaId = paradaId;
    }
    public long LinhaId { get; set; }
    public long ParadaId { get; set; }
}