using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Domain.Entity.LinhasParadas;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.Repositories.LinhasParadas;

public class LinhaParadaRepository :  ILinhaParadaRepository
{
    private readonly ApplicationDbContext _contexto;

    public LinhaParadaRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IEnumerable<Linha>> GetLinhasByParada(long paradaId)
    {
        var linhasParadas = await _contexto.LinhasParadas.Include(p => p.Linha).Include(p => p.Parada).Where(lp => lp.ParadaId == paradaId).ToListAsync();
        var linhas = linhasParadas.Select(lp => lp.Linha).ToList();
        return linhas != null ? linhas! : new List<Linha>();
    }

    public async Task<bool> Associate(LinhaParada linhaParada)
    {
        await _contexto.LinhasParadas.AddAsync(linhaParada);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Disassociate(LinhaParada linhaParada)
    {
        _contexto.LinhasParadas.Remove(linhaParada);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<IEnumerable<LinhaParada>> GetAllLinhasParadas()
    {
        return await _contexto.LinhasParadas.Include(p => p.Linha).Include(p => p.Parada).ToListAsync();
    }
}