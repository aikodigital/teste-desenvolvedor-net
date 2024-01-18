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
        return await _contexto.Veiculos.Include(v => v.Linha).ToListAsync();
    }

    public async Task<Veiculo> GetById(long id)
    {
        var veiculo = await _contexto.Veiculos.Include(v => v.Linha).FirstOrDefaultAsync(v => v.VeiculoId == id);
        return veiculo ?? throw new Exception("Veiculo not found.");
    }

    public async Task<bool> Add(Veiculo veiculo)
    {
        await _contexto.Veiculos.AddAsync(veiculo);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Update(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<bool> Remove(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        var statusOk = await _contexto.SaveChangesAsync();
        return statusOk > 0;
    }

    public async Task<IEnumerable<Veiculo>> GetVeiculosByLinha(long linhaId)
    {
        return await _contexto.Veiculos.Where(v => v.LinhaId == linhaId).ToListAsync();
    }
}