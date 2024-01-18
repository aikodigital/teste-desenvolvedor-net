using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.Paradas;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.Repositories.Paradas;

public class ParadaRepository :  IParadaRepository
{
    private readonly ApplicationDbContext _contexto;

    public ParadaRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Parada>> GetAll()
    {
        return await _contexto.Paradas.Include(p => p.LinhasParadas).ThenInclude(lp => lp.Linha).ToListAsync();
    }

    public async Task<Parada> GetById(long id)
    {
        var parada = await _contexto.Paradas.FindAsync(id);
        return parada ?? throw new Exception("Parada not found.");
    }

    public async Task<bool> Add(Parada parada)
    {
        await _contexto.Paradas.AddAsync(parada);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Update(Parada parada)
    {
        _contexto.Paradas.Update(parada);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Remove(Parada parada)
    {
        _contexto.Paradas.Remove(parada);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }
}