using Application.Repositories;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class VeiculoLinhaRepository : IVeiculoLinhaRepository
    {
        private readonly EFApplicationContext context;

        public VeiculoLinhaRepository(EFApplicationContext context)
        {
            this.context = context;
        }

        public List<IdNomeViewModel> ListarVeiculoPorLinha(int idLinha, DateTime dataUnicaOuInicial, DateTime? dataFinal = null)
        {
            var query = context.Set<RelVeiculoLinha>().Where(p => p.IdLinha == idLinha);
            if (dataFinal.HasValue)
            {
                query = query.Where(p => !(p.DataInicio > dataFinal || p.DataFim <= dataUnicaOuInicial));
            }
            else
            {
                query = query.Where(p => p.DataInicio <= dataUnicaOuInicial && p.DataFim > dataUnicaOuInicial);
            }

            return query.Select(p => new IdNomeViewModel
                        {
                            Id = p.IdVeiculo,
                            Nome = p.Veiculo.Nome
                        })
                        .ToList();
        }
    }
}
