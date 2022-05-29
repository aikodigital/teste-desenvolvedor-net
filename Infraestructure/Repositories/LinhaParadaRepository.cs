using Application.Repositories;
using Application.ViewModels;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class LinhaParadaRepository : ILinhaParadaRepository
    {
        private readonly EFApplicationContext context;

        public LinhaParadaRepository(EFApplicationContext context)
        {
            this.context = context;
        }

        public List<IdNomeViewModel> ListarLinhaPorParada(int idParada)
        {
            return context.Set<RelLinhaParada>()
                            .Where(p => p.IdParada == idParada)
                            .Select(p => new IdNomeViewModel
                            {
                                Id = p.IdLinha,
                                Nome = p.Linha.Nome
                            })
                            .ToList();
        }
    }
}
