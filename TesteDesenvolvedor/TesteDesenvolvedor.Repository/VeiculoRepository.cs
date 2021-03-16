using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Context;
using TesteDesenvolvedor.Repository.Generic;
using TesteDesenvolvedor.Repository.Interface;

namespace TesteDesenvolvedor.Repository
{
    public class VeiculoRepository : GenericRepository, IVeiculoRepository
    {
        public VeiculoRepository(DataContext context) : base(context) { }

        public async Task<Veiculo> FindByIdAsync(long id)
        {
            var result = await _context.Veiculos
                .Include(pv => pv.PosicaoVeiculo).AsNoTracking()
                .SingleOrDefaultAsync(l => l.Id.Equals(id));
            return result;
        }

        public async Task<List<Veiculo>> GetAllAsync()
        {
            var result = await _context.Veiculos.Include(p => p.Linha).Include(pv => pv.PosicaoVeiculo).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<Veiculo>> FindAllVeiculosByLinhasAsync(long linhaId)
        {
            var result = await _context.Veiculos
                    .Include(p => p.Linha)
                    .Include(pv => pv.PosicaoVeiculo)
                    .Where(p => p.LinhaId.Equals(linhaId)).AsNoTracking()
                    .ToListAsync();
            return result;
        }
        public async Task<List<Veiculo>> FindByNameSearchPage(string nome, int offset, int pageSize)
        {
            IQueryable<Veiculo> result = _context.Veiculos;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                result = result.Where(l => l.Nome.Contains(nome));
            }
            result = result.OrderBy(x => x.Nome)
                .Skip(offset)
                .Take(pageSize);

            return await result.ToListAsync();
        }

        public int GetCount(string nome)
        {
            IQueryable<Veiculo> result = _context.Veiculos;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                result = result.Where(l => l.Nome.Contains(nome));
            }
            return result.Count();
        }
    }
}