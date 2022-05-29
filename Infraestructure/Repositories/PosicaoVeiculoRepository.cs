using Application.Repositories;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PosicaoVeiculoRepository : IPosicaoVeiculoRepository
    {
        private readonly EFApplicationContext context;

        public PosicaoVeiculoRepository(EFApplicationContext context)
        {
            this.context = context;
        }

        public PosicaoVeiculoViewModel Consultar(int id)
        {
            return context.Set<PosicaoVeiculo>()
                            .Where(p => p.Id == id)
                            .Select(p => new PosicaoVeiculoViewModel
                            {
                                Id = p.Id,
                                Veiculo = new IdNomeViewModel
                                {
                                    Id = p.IdVeiculo,
                                    Nome = p.Veiculo.Nome
                                },
                                Latitude = p.Latitude,
                                Longitude = p.Longitude,
                                DataPosicao = p.DataPosicao
                            })
                            .FirstOrDefault();
        }

        public List<PosicaoVeiculoViewModel> Listar(int idVeiculo, DateTime dataUnicaOuInicial, DateTime? dataFinal = null)
        {
            var query = context.Set<PosicaoVeiculo>().Where(p => p.IdVeiculo == idVeiculo);

            if (dataFinal.HasValue)
            {
                query = query.Where(p => p.DataPosicao >= dataUnicaOuInicial && p.DataPosicao <= dataFinal.Value);
            }
            else
            {
                query = query.Where(p => p.DataPosicao.Date == dataUnicaOuInicial.Date);
            }

            return query.OrderBy(p => p.DataPosicao)
                        .Select(p => new PosicaoVeiculoViewModel
                        {
                            Id = p.Id,
                            Veiculo = new IdNomeViewModel
                            {
                                Id = p.IdVeiculo,
                                Nome = p.Veiculo.Nome
                            },
                            Latitude = p.Latitude,
                            Longitude = p.Longitude,
                            DataPosicao = p.DataPosicao
                        })
                        .ToList();
        }

        public void Cadastrar(PosicaoVeiculoViewModel dados)
        {
            context.Set<PosicaoVeiculo>().Add(new PosicaoVeiculo
            {
                IdVeiculo = dados.Veiculo.Id,
                Latitude = dados.Latitude,
                Longitude = dados.Longitude,
                DataPosicao = dados.DataPosicao ?? DateTime.Now
            });

            context.SaveChanges();
        }

        public void Alterar(PosicaoVeiculoViewModel dados)
        {
            context.Set<PosicaoVeiculo>().Update(new PosicaoVeiculo
            {
                Id = dados.Id,
                IdVeiculo = dados.Veiculo.Id,
                Latitude = dados.Latitude,
                Longitude = dados.Longitude,
                DataPosicao = dados.DataPosicao.Value
            });

            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var dados = context.Set<PosicaoVeiculo>().Where(p => p.Id == id).FirstOrDefault();

            if (dados != null)
            {
                context.Set<PosicaoVeiculo>().Remove(dados);

                context.SaveChanges();
            }
        }
    }
}
