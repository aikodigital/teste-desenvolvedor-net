using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Queries.Linhas.GetAll;

public class GetAllLinhasQueryHandler : IRequestHandler<GetAllLinhasQuery, IEnumerable<LinhaDto>>
{
    private readonly IMapper _mapper;
    private readonly ILinhaRepository _linhaRepository;

    public GetAllLinhasQueryHandler(ILinhaRepository linhaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _linhaRepository = linhaRepository;
    }
    

    public async Task<IEnumerable<LinhaDto>> Handle(GetAllLinhasQuery request,
        CancellationToken cancellationToken)
    {
        var linhas = await _linhaRepository.GetAll();
        return _mapper.Map<IEnumerable<LinhaDto>>(linhas);
    }
}