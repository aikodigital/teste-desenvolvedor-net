using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Commands.Linhas.Create;

public class CreateLinhaCommandHandler : IRequestHandler<CreateLinhaCommand, bool>
{
    private readonly ILinhaRepository _linhaRepository;
    private readonly IMapper _mapper;

    public CreateLinhaCommandHandler(ILinhaRepository linhaRepository, 
        IMapper mapper)
    {
        _linhaRepository = linhaRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateLinhaCommand request, CancellationToken cancellationToken)
    {
        var linha = _mapper.Map<Linha>(request.Dto);
        var statusOk = await _linhaRepository.Add(linha);
        return statusOk;
    }
}