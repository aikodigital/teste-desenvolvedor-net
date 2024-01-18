using MediatR;

namespace TransportePublico.App.Commands.Veiculos.Create;
public class CreateVeiculoCommand : IRequest<bool>
{
    public CreateVeiculoCommand(NewVeiculoDto dto)
    {
        Dto = dto;
    }
    
    public NewVeiculoDto? Dto { get; set; }
}