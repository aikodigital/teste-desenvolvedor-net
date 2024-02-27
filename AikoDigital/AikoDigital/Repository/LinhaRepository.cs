using AikoDigital.Contexto;
using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;

namespace AikoDigital.Repository
{
    public class LinhaRepository
    {
        private readonly AppDbContext _context;

        public LinhaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Linha>>? Get()
        {
            return await _context.Linhas.ToListAsync();
        }

        public async Task<Linha>? GetById(long id)
        {
            return await _context.Linhas.FindAsync(id);
        }

        public async Task Create(Linha linha)
        {
            _context.Linhas.Add(linha);
            await _context.SaveChangesAsync();
        }

        public async Task Update(long id, Linha linha)
        {
            var objeto = await _context.Linhas.FindAsync(id);

            objeto.Name = linha.Name;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var linha = await _context.Linhas.FindAsync(id);
            _context.Linhas.Remove(linha);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Linha>> GetLinhasParada(long idParada)
        {
            return await _context.LinhaParadas.Where(lp => lp.ParadaId == idParada).Include(lp => lp.Linhas).Select(lp => lp.Linhas).ToListAsync();
        }
    }
}
