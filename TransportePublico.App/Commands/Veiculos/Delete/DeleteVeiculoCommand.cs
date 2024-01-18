using MediatR;

namespace TransportePublico.App.Commands.Veiculos.Delete;
public class DeleteVeiculoCommand : IRequest<bool>
{
    public DeleteVeiculoCommand(long id)
    {
        Id = id;
    }
    
    public long Id { get; set; }
}