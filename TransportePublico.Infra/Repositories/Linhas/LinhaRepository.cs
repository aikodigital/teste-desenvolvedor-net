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
}