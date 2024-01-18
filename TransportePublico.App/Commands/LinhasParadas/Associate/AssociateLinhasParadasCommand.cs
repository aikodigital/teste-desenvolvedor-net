using MediatR;

namespace TransportePublico.App.Commands.LinhasParadas.Associate;
public class AssociateLinhasParadasCommand : IRequest<bool>
{
    public AssociateLinhasParadasCommand(long linhaId, long paradaId)
    {
        LinhaId = linhaId;
        ParadaId = paradaId;
    }
    public long LinhaId { get; set; }
    public long ParadaId { get; set; }
}