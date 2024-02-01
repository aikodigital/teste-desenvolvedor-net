using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Linha.Delete;

/// <summary>
/// Handler responsável por excluir uma linha cadastrada.
/// </summary>
public class DeleteLineCommandHandler : IRequestHandler<DeleteLineCommand, Result<LineModel>>
{
    private readonly IMapper _mapper;
    private readonly ILineRepository _lineRepository;

    public DeleteLineCommandHandler(IMapper mapper, ILineRepository lineRepository)
    {
        _mapper = mapper;
        _lineRepository = lineRepository;
    }

    public async Task<Result<LineModel>> Handle(DeleteLineCommand command, CancellationToken cancellationToken)
    {
        var erros = Array.Empty<string>();

        var line = (await _lineRepository.ListAsync(command.Id)).First();
        
        await _lineRepository.DeleteAsync(line);

        return new()
        {
            Erros = erros,
            Retorno = _mapper.Map<LineModel>(line),
            Sucesso = !erros.Any()
        };
    }
}