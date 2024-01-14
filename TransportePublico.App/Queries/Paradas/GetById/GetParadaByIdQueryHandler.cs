using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.Queries.Paradas.GetById;

public class GetParadaByIdQueryHandler : IRequestHandler<GetParadaByIdQuery, ParadaDto>
{
    private readonly IMapper _mapper;
    private readonly IParadaRepository _paradaRepository;

    public GetParadaByIdQueryHandler(IParadaRepository paradaRepository, IMapper mapper)
    {
        _mapper = mapper;
        _paradaRepository = paradaRepository;
    }
    

    public async Task<ParadaDto> Handle(GetParadaByIdQuery request,
        CancellationToken cancellationToken)
    {
        var parada = await _paradaRepository.GetById(request.Id);
        return _mapper.Map<ParadaDto>(parada);
    }
}