using AikoDigital.Contexto;
using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Repository
{
    public class PosicaoVeiculoRepository
    {
        private readonly AppDbContext _context;

        public PosicaoVeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PosicaoVeiculo>>? Get()
        {
            return await _context.PosicaoVeiculos.ToListAsync();
        }

        public async Task<PosicaoVeiculo>? GetById(long id)
        {
            return await _context.PosicaoVeiculos.FindAsync(id);
        }

        public async Task Create(PosicaoVeiculo posicaoVeiculo)
        {
            _context.PosicaoVeiculos.Add(posicaoVeiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(long id, PosicaoVeiculo posicaoVeiculo)
        {
            var objeto = await _context.PosicaoVeiculos.FindAsync(id);

            objeto.Latitude = posicaoVeiculo.Latitude;
            objeto.Longitude = posicaoVeiculo.Longitude;
            objeto.VeiculoId = posicaoVeiculo.VeiculoId;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var posicaoVeiculo = await _context.PosicaoVeiculos.FindAsync(id);
            _context.PosicaoVeiculos.Remove(posicaoVeiculo);
            await _context.SaveChangesAsync();
        }
    }
}
