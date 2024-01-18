using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Commands.Veiculos.Update;

public class UpdateVeiculoCommandHandler : IRequestHandler<UpdateVeiculoCommand, bool>
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMapper _mapper;

    public UpdateVeiculoCommandHandler(IVeiculoRepository veiculoRepository, 
        IMapper mapper)
    {
        _veiculoRepository = veiculoRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = _mapper.Map<Veiculo>(request.Dto);
        var statusOk = await _veiculoRepository.Update(veiculo);
        return statusOk;
    }
}