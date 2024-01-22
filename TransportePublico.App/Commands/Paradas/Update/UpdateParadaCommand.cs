using MediatR;

namespace TransportePublico.App.Commands.Paradas.Update;
public class UpdateParadaCommand : IRequest<bool>
{
    public UpdateParadaCommand(UpdateParadaDto dto)
    {
        Dto = dto;
    }
    
    public UpdateParadaDto? Dto { get; set; }
}