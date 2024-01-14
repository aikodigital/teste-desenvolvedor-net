using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Queries.Linhas.GetById;

public class GetLinhasByIdQueryHandler : IRequestHandler<GetLinhasByIdQuery, LinhaDto>
{
    private readonly IMapper _mapper;
    private readonly ILinhaRepository _linhaRepository;

    public GetLinhasByIdQueryHandler(ILinhaRepository linhaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _linhaRepository = linhaRepository;
    }
    

    public async Task<LinhaDto> Handle(GetLinhasByIdQuery request,
        CancellationToken cancellationToken)
    {
        var pleitos = await _linhaRepository.GetById(request.Id);
        return _mapper.Map<LinhaDto>(pleitos);
    }
}