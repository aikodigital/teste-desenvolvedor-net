using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Queries.Linhas.GetById;

public class GetLinhaByIdQueryHandler : IRequestHandler<GetLinhaByIdQuery, LinhaDto>
{
    private readonly IMapper _mapper;
    private readonly ILinhaRepository _linhaRepository;

    public GetLinhaByIdQueryHandler(ILinhaRepository linhaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _linhaRepository = linhaRepository;
    }
    

    public async Task<LinhaDto> Handle(GetLinhaByIdQuery request,
        CancellationToken cancellationToken)
    {
        var linha = await _linhaRepository.GetById(request.Id);
        return _mapper.Map<LinhaDto>(linha);
    }
}