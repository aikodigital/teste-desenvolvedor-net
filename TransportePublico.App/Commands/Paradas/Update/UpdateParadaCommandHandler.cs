using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.App.Commands.Paradas.Update;

public class UpdateParadaCommandHandler : IRequestHandler<UpdateParadaCommand, bool>
{
    private readonly IParadaRepository _paradaRepository;
    private readonly IMapper _mapper;

    public UpdateParadaCommandHandler(IParadaRepository paradaRepository, 
        IMapper mapper)
    {
        _paradaRepository = paradaRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateParadaCommand request, CancellationToken cancellationToken)
    {
        var parada = _mapper.Map<Parada>(request.Dto);
        var statusOk = await _paradaRepository.Update(parada);
        return statusOk;
    }
}