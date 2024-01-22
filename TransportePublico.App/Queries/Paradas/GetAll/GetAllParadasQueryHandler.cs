using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.Queries.Paradas.GetAll;

public class GetAllParadasQueryHandler : IRequestHandler<GetAllParadasQuery, IEnumerable<ParadaDto>>
{
    private readonly IMapper _mapper;
    private readonly IParadaRepository _paradaRepository;

    public GetAllParadasQueryHandler(IParadaRepository paradaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _paradaRepository = paradaRepository;
    }
    

    public async Task<IEnumerable<ParadaDto>> Handle(GetAllParadasQuery request,
        CancellationToken cancellationToken)
    {
        var paradas = await _paradaRepository.GetAll();
        return _mapper.Map<IEnumerable<ParadaDto>>(paradas);
    }
}