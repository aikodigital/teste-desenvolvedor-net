using MediatR;

namespace TransportePublico.App.Commands.PosicoesVeiculos.Create;
public class CreatePosicaoVeiculoCommand : IRequest<bool>
{
    public CreatePosicaoVeiculoCommand(NewPosicaoVeiculoDto dto)
    {
        Dto = dto;
    }
    
    public NewPosicaoVeiculoDto? Dto { get; set; }
}