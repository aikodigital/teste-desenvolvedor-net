using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Queries.Veiculos.GetById;

public class GetVeiculoByIdQueryHandler : IRequestHandler<GetVeiculoByIdQuery, VeiculoDto>
{
    private readonly IMapper _mapper;
    private readonly IVeiculoRepository _veiculoRepository;

    public GetVeiculoByIdQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _veiculoRepository = veiculoRepository;
    }
    

    public async Task<VeiculoDto> Handle(GetVeiculoByIdQuery request,
        CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.GetById(request.Id);
        return _mapper.Map<VeiculoDto>(veiculo);
    }
}