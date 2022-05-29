using Application.Repositories;
using Application.ViewModels;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly EFApplicationContext context;

        public VeiculoRepository(EFApplicationContext context)
        {
            this.context = context;
        }

        public VeiculoViewModel Consultar(int id)
        {
            return context.Set<Veiculo>()
                            .Where(p => p.Id == id)
                            .Select(p => new VeiculoViewModel
                            {
                                Id = p.Id,
                                Nome = p.Nome,
                                Modelo = p.Modelo
                            })
                            .FirstOrDefault();
        }

        public VeiculoViewModel Consultar(string nome)
        {
            return context.Set<Veiculo>()
                            .Where(p => p.Nome.ToLower() == nome.ToLower() && p.Ativo)
                            .Select(p => new VeiculoViewModel
                            {
                                Id = p.Id,
                                Nome = p.Nome,
                                Modelo = p.Modelo
                            })
                            .FirstOrDefault();
        }

        public List<IdNomeViewModel> Listar(bool somenteAtivos = true)
        {
            var query = context.Set<Veiculo>().AsQueryable();

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

        public void Cadastrar(VeiculoViewModel dados)
        {
            context.Set<Veiculo>().Add(new Veiculo
            {
                Nome = dados.Nome,
                Modelo = dados.Modelo,
                Ativo = true
            });

            context.SaveChanges();
        }

        public void Alterar(VeiculoViewModel dados, bool ativo = true)
        {
            context.Set<Veiculo>().Update(new Veiculo
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Modelo = dados.Modelo,
                Ativo = ativo
            });

            context.SaveChanges();
        }
    }
}
