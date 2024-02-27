using AikoDigital.Contexto;
using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace AikoDigital.Repository
{
    public class VeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>>? Get()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<Veiculo>? GetById(long id)
        {
            return await _context.Veiculos.FindAsync(id);
        }

        public async Task Create(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(long id, Veiculo veiculo)
        {
            var objeto = await _context.Veiculos.FindAsync(id);

            objeto.Name = veiculo.Name;
            objeto.Modelo = veiculo.Modelo;
            objeto.LinhaId = veiculo.LinhaId;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var parada = await _context.Veiculos.FindAsync(id);
            _context.Veiculos.Remove(parada);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> GetVeiculosPorLinha(long IdLinha)
        {
            return  await _context.Veiculos.Where(v => v.LinhaId ==  IdLinha).ToListAsync();
        }
    }
}
