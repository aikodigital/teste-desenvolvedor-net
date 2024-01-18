using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Commands.Veiculos.Create;

public class CreateVeiculoCommandHandler : IRequestHandler<CreateVeiculoCommand, bool>
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMapper _mapper;

    public CreateVeiculoCommandHandler(IVeiculoRepository veiculoRepository, 
        IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = _mapper.Map<Veiculo>(request.Dto);
        var statusOk = await _veiculoRepository.Add(veiculo);
        return statusOk;
    }
}