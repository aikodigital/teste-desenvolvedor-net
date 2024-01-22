using AutoMapper;
using MediatR;
using TransportePublico.App.Queries.Linhas;
using TransportePublico.Domain.Entity.LinhasParadas;

namespace TransportePublico.App.Queries.LinhasParadas.GetLinhasByParada;

public class GetLinhasByParadaQueryHandler : IRequestHandler<GetLinhasByParadaQuery, IEnumerable<LinhaDto>>
{
    private readonly IMapper _mapper;
    private readonly ILinhaParadaRepository _linhaParadaRepository;

    public GetLinhasByParadaQueryHandler(ILinhaParadaRepository linhaParadaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _linhaParadaRepository = linhaParadaRepository;
    }
    

    public async Task<IEnumerable<LinhaDto>> Handle(GetLinhasByParadaQuery request, CancellationToken cancellationToken)
    {
        var linhas = await _linhaParadaRepository.GetLinhasByParada(request.ParadaId);
        return _mapper.Map<IEnumerable<LinhaDto>>(linhas);
    }
}