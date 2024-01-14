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
        return await _contexto.Paradas.ToListAsync();
    }

    public async Task<Parada> GetById(long id)
    {
        var parada = await _contexto.Paradas.FindAsync(id);
        return parada ?? throw new Exception("Parada not found.");
    }
}