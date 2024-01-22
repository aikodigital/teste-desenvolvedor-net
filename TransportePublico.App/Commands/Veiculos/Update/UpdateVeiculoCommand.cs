using MediatR;

namespace TransportePublico.App.Commands.Veiculos.Update;
public class UpdateVeiculoCommand : IRequest<bool>
{
    public UpdateVeiculoCommand(UpdateVeiculoDto dto)
    {
        Dto = dto;
    }
    
    public UpdateVeiculoDto? Dto { get; set; }
}