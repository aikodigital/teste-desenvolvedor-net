using System;
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
    public class ParadaRepository : GenericRepository, IParadaRepository
    {

        public ParadaRepository(DataContext context) : base(context){}

        public async Task<Parada> FindByIdAsync(long id)
        {
            var result = await _context.Paradas.AsNoTracking()
                            .SingleOrDefaultAsync(p => p.Id.Equals(id));
            return result;
        }

        public async Task<List<Parada>> GetAllAsync()
        {
            var result = await _context.Paradas.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<Parada>> FindParadaByPosicao(double lat, double lng, double distancia)
        {
            var result = await _context.Paradas
                .FromSqlRaw(@"SELECT *, (6371 * acos(cos(radians({0})) * cos(radians(Latitude)) * 
                            cos( radians( Longitude ) - radians({1}) ) + sin( radians({0}) ) * 
                            sin(radians(latitude)) ) ) AS distance  
                            FROM paradas HAVING distance < {2}
                            ORDER BY distance", lat, lng, distancia)
                .ToListAsync();
            return result;           
        }

         public async Task<List<Parada>> FindByNameSearchPage(string nome, int offset, int pageSize)
        {   
            IQueryable<Parada> result = _context.Paradas;
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
            IQueryable<Parada> result = _context.Paradas;
            
            if(!string.IsNullOrWhiteSpace(nome)){
                result = result.Where(l => l.Nome.Contains(nome));
            }
           return result.Count();
        }

    }
}