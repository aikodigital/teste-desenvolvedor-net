using MediatR;

namespace TransportePublico.App.Commands.Paradas.Create;
public class CreateParadaCommand : IRequest<bool>
{
    public CreateParadaCommand(NewParadaDto dto)
    {
        Dto = dto;
    }
    
    public NewParadaDto? Dto { get; set; }
}