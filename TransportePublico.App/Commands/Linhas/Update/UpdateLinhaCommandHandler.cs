using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Commands.Linhas.Update;

public class UpdateLinhaCommandHandler : IRequestHandler<UpdateLinhaCommand, bool>
{
    private readonly ILinhaRepository _linhaRepository;
    private readonly IMapper _mapper;

    public UpdateLinhaCommandHandler(ILinhaRepository linhaRepository, 
        IMapper mapper)
    {
        _linhaRepository = linhaRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateLinhaCommand request, CancellationToken cancellationToken)
    {
        var linha = _mapper.Map<Linha>(request.Dto);
        var statusOk = await _linhaRepository.Update(linha);
        return statusOk;
    }
}