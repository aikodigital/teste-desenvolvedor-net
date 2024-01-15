using AutoMapper;
using MediatR;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.App.Commands.Linhas.Delete;

public class DeleteLinhaCommandHandler : IRequestHandler<DeleteLinhaCommand, bool>
{
    private readonly ILinhaRepository _linhaRepository;

    public DeleteLinhaCommandHandler(ILinhaRepository linhaRepository)
    {
        _linhaRepository = linhaRepository;
    }

    public async Task<bool> Handle(DeleteLinhaCommand request, CancellationToken cancellationToken)
    {
        var linha = await _linhaRepository.GetById(request.Id);
        var statusOk = await _linhaRepository.Remove(linha);
        return statusOk;
    }
}