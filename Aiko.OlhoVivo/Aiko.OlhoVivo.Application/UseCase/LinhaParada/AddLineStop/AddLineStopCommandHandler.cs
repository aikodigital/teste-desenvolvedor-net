using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.LinhaParada.AddLineStop;

public class AddLineStopCommandHandler : IRequestHandler<AddLineStopCommand, Result<LineStopModel>>
{
    private readonly IMapper _mapper;
    private readonly ILineStopRepository _lineStopRepository;

    public AddLineStopCommandHandler(IMapper mapper, ILineStopRepository lineStopRepository)
    {
        _mapper = mapper;
        _lineStopRepository = lineStopRepository;
    }

    public async Task<Result<LineStopModel>> Handle(AddLineStopCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var lineStop = _mapper.Map<LineStop>(command);

        await _lineStopRepository.AddAsync(lineStop);

        return new()
        {   
            Erros = erros,
            Retorno = _mapper.Map<LineStopModel>(lineStop),
            Sucesso = !erros.Any()
        };
    }
}