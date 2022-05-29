using Application.Repositories;
using Application.ViewModels;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class LinhaRepository : ILinhaRepository
    {
        private readonly EFApplicationContext context;

        public LinhaRepository(EFApplicationContext context)
        {
            this.context = context;
        }

        public IdNomeViewModel Consultar(int id)
        {
            return context.Set<Linha>()
                            .Where(p => p.Id == id)
                            .Select(p => new IdNomeViewModel
                            {
                                Id = p.Id,
                                Nome = p.Nome
                            })
                            .FirstOrDefault();
        }

        public IdNomeViewModel Consultar(string nome)
        {
            return context.Set<Linha>()
                            .Where(p => p.Nome.ToLower() == nome.ToLower() && p.Ativo)
                            .Select(p => new IdNomeViewModel
                            {
                                Id = p.Id,
                                Nome = p.Nome
                            })
                            .FirstOrDefault();
        }

        public List<IdNomeViewModel> Listar(bool somenteAtivos = true)
        {
            var query = context.Set<Linha>().AsQueryable();

            if (somenteAtivos)
            {
                query = query.Where(p => p.Ativo);
            }

            return query.OrderBy(p => p.Nome)
                        .Select(p => new IdNomeViewModel
                        {
                            Id = p.Id,
                            Nome = p.Nome
                        })
                        .ToList();
        }

        public void Cadastrar(IdNomeViewModel dados)
        {
            context.Set<Linha>().Add(new Linha
            {
                Nome = dados.Nome,
                Ativo = true
            });

            context.SaveChanges();
        }

        public void Alterar(IdNomeViewModel dados, bool ativo = true)
        {
            context.Set<Linha>().Update(new Linha
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Ativo = ativo
            });

            context.SaveChanges();
        }
    }
}
