using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.PosicoesVeiculos;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.Repositories.PosicoesVeiculos;

public class PosicaoVeiculoRepository :  IPosicaoVeiculoRepository
{
    private readonly ApplicationDbContext _contexto;

    public PosicaoVeiculoRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<PosicaoVeiculo>> GetAll()
    {
        return await _contexto.PosicoesVeiculos.Include(l => l.Veiculo).ToListAsync();
    }

    public async Task<PosicaoVeiculo> GetById(long id)
    {
        var posicaoVeiculo = await _contexto.PosicoesVeiculos.Include(l => l.Veiculo).FirstOrDefaultAsync(l => l.PosicaoVeiculoId == id);
        return posicaoVeiculo ?? throw new Exception("Position of Vehicle is not found.");
    }

    public async Task<bool> Add(PosicaoVeiculo posicaoVeiculo)
    {
        await _contexto.PosicoesVeiculos.AddAsync(posicaoVeiculo);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Update(PosicaoVeiculo posicaoVeiculo)
    {
        _contexto.PosicoesVeiculos.Update(posicaoVeiculo);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Remove(PosicaoVeiculo posicaoVeiculo)
    {
        _contexto.PosicoesVeiculos.Remove(posicaoVeiculo);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }
}