using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.Repositories.Linhas;

public class LinhaRepository :  ILinhaRepository
{
    private readonly ApplicationDbContext _contexto;

    public LinhaRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Linha>> GetAll()
    {
        return await _contexto.Linhas.ToListAsync();
    }

    public async Task<Linha> GetById(long id)
    {
        var linha = await _contexto.Linhas.FindAsync(id);
        return linha ?? throw new Exception("Linha not found.");
    }

    public async Task<bool> Add(Linha linha)
    {
        await _contexto.Linhas.AddAsync(linha);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Update(Linha linha)
    {
        _contexto.Linhas.Update(linha);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Remove(Linha linha)
    {
        _contexto.Linhas.Remove(linha);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }
}