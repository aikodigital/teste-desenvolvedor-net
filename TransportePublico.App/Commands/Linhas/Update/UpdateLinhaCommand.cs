using MediatR;

namespace TransportePublico.App.Commands.Linhas.Update;
public class UpdateLinhaCommand : IRequest<bool>
{
    public UpdateLinhaCommand(UpdateLinhaDto dto)
    {
        Dto = dto;
    }
    
    public UpdateLinhaDto? Dto { get; set; }
}