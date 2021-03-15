using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Context;
using TesteDesenvolvedor.Repository.Generic;
using TesteDesenvolvedor.Repository.Interface;

namespace TesteDesenvolvedor.Repository
{
    public class PosicaoVeiculoRepository : GenericRepository, IPosicaoVeiculoRepository
    {

        public PosicaoVeiculoRepository(DataContext context) : base(context){}
        
        public async Task<PosicaoVeiculo> FindByIdVeiculoAsync(long VeiculoId)
        {
            var result = await _context.PosicaoVeiculos.AsNoTracking()
                    .SingleOrDefaultAsync(l => l.VeiculoId.Equals(VeiculoId));
            return result;
        }

        public async Task<PosicaoVeiculo> FindByIdAsync(long id)
        {
            var result = await _context.PosicaoVeiculos.AsNoTracking()
                  .SingleOrDefaultAsync(l => l.Id.Equals(id));
            return result;
        }

        public async Task<List<PosicaoVeiculo>> GetAllAsync()
        {
            var result = await _context.PosicaoVeiculos.ToListAsync();
            return result;
        }
    }
}