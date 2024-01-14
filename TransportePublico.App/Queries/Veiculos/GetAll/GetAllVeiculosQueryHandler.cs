using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Queries.Veiculos.GetAll;

public class GetAllVeiculosQueryHandler : IRequestHandler<GetAllVeiculosQuery, IEnumerable<VeiculoDto>>
{
    private readonly IMapper _mapper;
    private readonly IVeiculoRepository _veiculoRepository;

    public GetAllVeiculosQueryHandler(IVeiculoRepository veiculoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _veiculoRepository = veiculoRepository;
    }
    

    public async Task<IEnumerable<VeiculoDto>> Handle(GetAllVeiculosQuery request,
        CancellationToken cancellationToken)
    {
        var veiculos = await _veiculoRepository.GetAll();
        return _mapper.Map<IEnumerable<VeiculoDto>>(veiculos);
    }
}