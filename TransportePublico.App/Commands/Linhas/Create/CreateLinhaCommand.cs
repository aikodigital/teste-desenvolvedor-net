using MediatR;

namespace TransportePublico.App.Commands.Linhas.Create;
public class CreateLinhaCommand : IRequest<bool>
{
    public CreateLinhaCommand(NewLinhaDto dto)
    {
        Dto = dto;
    }
    
    public NewLinhaDto? Dto { get; set; }
}