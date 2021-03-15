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
    public class LinhaRepository : GenericRepository, ILinhaRepository
    {
        public LinhaRepository(DataContext context) : base(context) { }

        public async Task<Linha> FindByIdAsync(long id)
        {
            var result = await _context.Linhas.AsNoTracking()
                   .SingleOrDefaultAsync(l => l.Id.Equals(id));
            return result;
        }

        public async Task<List<Linha>> GetAllAsync()
        {
            var result = await _context.Linhas
                    .Include(x => x.LinhasParadas)
                    .ThenInclude(p => p.Parada)
                    .Include(v => v.Veiculos).AsNoTracking()
                    .ToListAsync();
            return result;
        }

        public async Task<List<Linha>> FindAllLinhasByParadasAsync(long paradaId)
        {
            var result = await (from linha in _context.Linhas
                join linhasParadas in _context.LinhasParadas
                on linha.Id equals linhasParadas.LinhaId
                where linhasParadas.ParadaId == paradaId
                select new Linha{
                    Id = linha.Id,
                    Nome = linha.Nome,
                    Veiculos = linha.Veiculos
                    
                }
                ).ToListAsync();
          return result;

        }

        public async Task<List<Linha>> FindByNameSearchPage(string nome, int offset, int pageSize)
        {   
            IQueryable<Linha> result = _context.Linhas;
            if(!string.IsNullOrWhiteSpace(nome)){
                result = result.Where(l => l.Nome.Contains(nome));
            }
            result = result.OrderBy(x=>x.Nome)
                .Skip(offset)
                .Take(pageSize);

            return await result.ToListAsync();
        }

        public int GetCount(string nome)
        { 
            IQueryable<Linha> result = _context.Linhas;
            
            if(!string.IsNullOrWhiteSpace(nome)){
                result = result.Where(l => l.Nome.Contains(nome));
            }
           return result.Count();
        }
    }
}