using MediatR;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Update;
public class UpdatePosicaoVeiculoCommand : IRequest<bool>
{
    public UpdatePosicaoVeiculoCommand(UpdatePosicaoVeiculoDto dto)
    {
        Dto = dto;
    }
    
    public UpdatePosicaoVeiculoDto? Dto { get; set; }
}