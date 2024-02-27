using AikoDigital.Contexto;
using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Repository
{
    public class ParadaRepository
    {
        private readonly AppDbContext _context;

        public ParadaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parada>>? Get()
        {
            return await _context.Paradas.ToListAsync();
        }

        public async Task<Parada>? GetById(long id)
        {
            return await _context.Paradas.FindAsync(id);
        }

        public async Task Create(Parada parada)
        {
            _context.Paradas.Add(parada);
            await _context.SaveChangesAsync();
        }

        public async Task Update(long id, Parada parada)
        {
            var objeto = _context.Paradas.Find(id);

            objeto.Name = parada.Name;
            objeto.Latitude = parada.Latitude;
            objeto.Longitude = parada.Longitude;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var parada = await _context.Paradas.FindAsync(id);
            _context.Paradas.Remove(parada);
            await _context.SaveChangesAsync();
        }
    }
}
