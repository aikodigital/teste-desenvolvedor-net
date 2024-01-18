using MediatR;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Delete;
public class DeletePosicaoVeiculoCommand : IRequest<bool>
{
    public DeletePosicaoVeiculoCommand(long id)
    {
        Id = id;
    }
    
    public long Id { get; set; }
}