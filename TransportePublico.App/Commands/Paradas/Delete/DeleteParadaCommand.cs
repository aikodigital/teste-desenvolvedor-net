using MediatR;

namespace TransportePublico.App.Commands.Paradas.Delete;
public class DeleteParadaCommand : IRequest<bool>
{
    public DeleteParadaCommand(long id)
    {
        Id = id;
    }
    
    public long Id { get; set; }
}