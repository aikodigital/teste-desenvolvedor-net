using Application.Repositories;
using Application.ViewModels;
using Domain.Models;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Distance;
using NetTopologySuite.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ParadaRepository : IParadaRepository
    {
        private readonly EFApplicationContext context;

        public ParadaRepository(EFApplicationContext context)
        {
            this.context = context;
        }

        public ParadaViewModel Consultar(int id)
        {
            return context.Set<Parada>()
                            .Where(p => p.Id == id)
                            .Select(p => new ParadaViewModel
                            {
                                Id = p.Id,
                                Nome = p.Nome,
                                Latitude = p.Latitude,
                                Longitude = p.Longitude
                            })
                            .FirstOrDefault();
        }

        public ParadaViewModel Consultar(string nome)
        {
            return context.Set<Parada>()
                            .Where(p => p.Nome.ToLower() == nome.ToLower() && p.Ativo)
                            .Select(p => new ParadaViewModel
                            {
                                Id = p.Id,
                                Nome = p.Nome,
                                Latitude = p.Latitude,
                                Longitude = p.Longitude
                            })
                            .FirstOrDefault();
        }

        public List<IdNomeViewModel> Listar(bool somenteAtivos = true)
        {
            var query = context.Set<Parada>().AsQueryable();

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

        public List<ParadaViewModel> ListarPorPosicao(double latitude, double longitude, int quantidade)
        {
            var ponto = new Point(longitude, latitude);

            var query = context.Set<Parada>().ToList();

            return query.Select(p => new
                        {
                            p.Id,
                            p.Nome,
                            p.Latitude,
                            p.Longitude,
                            Distancia = DistanceOp.Distance(ponto, new Point(p.Longitude, p.Latitude))
                        })
                        .OrderBy(p => p.Distancia)
                        .Select(p => new ParadaViewModel
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Latitude = p.Latitude,
                            Longitude = p.Longitude
                        })
                        .Take(quantidade)
                        .ToList();
        }

        public void Cadastrar(ParadaViewModel dados)
        {
            context.Set<Parada>().Add(new Parada
            {
                Nome = dados.Nome,
                Latitude = dados.Latitude,
                Longitude = dados.Longitude,
                Ativo = true
            });

            context.SaveChanges();
        }

        public void Alterar(ParadaViewModel dados, bool ativo = true)
        {
            context.Set<Parada>().Update(new Parada
            {
                Id = dados.Id,
                Nome = dados.Nome,
                Latitude = dados.Latitude,
                Longitude = dados.Longitude,
                Ativo = ativo
            });

            context.SaveChanges();
        }
    }
}
