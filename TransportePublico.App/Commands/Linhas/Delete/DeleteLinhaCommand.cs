using MediatR;

namespace TransportePublico.App.Commands.Linhas.Delete;
public class DeleteLinhaCommand : IRequest<bool>
{
    public DeleteLinhaCommand(long id)
    {
        Id = id;
    }
    
    public long Id { get; set; }
}