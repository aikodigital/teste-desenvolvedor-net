using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.Commands.Paradas.Create;

public class CreateParadaCommandHandler : IRequestHandler<CreateParadaCommand, bool>
{
    private readonly IParadaRepository _paradaRepository;
    private readonly IMapper _mapper;

    public CreateParadaCommandHandler(IParadaRepository paradaRepository, 
        IMapper mapper)
    {
        _paradaRepository = paradaRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateParadaCommand request, CancellationToken cancellationToken)
    {
        var parada = _mapper.Map<Parada>(request.Dto);
        var statusOk = await _paradaRepository.Add(parada);
        return statusOk;
    }
}