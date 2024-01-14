using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.PosicoesVeiculos;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.Repositories.Paradas;

public class PosicaoVeiculoRepository :  IPosicaoVeiculoRepository
{
    private readonly ApplicationDbContext _contexto;

    public PosicaoVeiculoRepository(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<PosicaoVeiculo>> GetAll()
    {
        return await _contexto.PosicoesVeiculos.ToListAsync();
    }

    public async Task<PosicaoVeiculo> GetById(long id)
    {
        var posicaoVeiculo = await _contexto.PosicoesVeiculos.FindAsync(id);
        return posicaoVeiculo ?? throw new Exception("Position of Vehicle is not found.");
    }
}