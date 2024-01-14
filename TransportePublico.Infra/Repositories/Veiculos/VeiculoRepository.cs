using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.Veiculos;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.Repositories.Veiculos;

public class VeiculoRepository :  IVeiculoRepository
{
    private readonly ApplicationDbContext _contexto;

    public VeiculoRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Veiculo>> GetAll()
    {
        return await _contexto.Veiculos.ToListAsync();
    }

    public async Task<Veiculo> GetById(long id)
    {
        var veiculo = await _contexto.Veiculos.FindAsync(id);
        return veiculo ?? throw new Exception("Veiculo not found.");
    }
}