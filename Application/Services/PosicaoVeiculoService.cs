using Application.Exceptions;
using Application.Repositories;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class PosicaoVeiculoService
    {
        private readonly IPosicaoVeiculoRepository repository;

        public PosicaoVeiculoService(IPosicaoVeiculoRepository repository)
        {
            this.repository = repository;
        }

        public PosicaoVeiculoViewModel Consultar(int id)
        {
            if (id == 0)
            {
                throw new AikoException($"Informe o identificador!");
            }

            var dados = repository.Consultar(id);
            if (dados == null)
            {
                throw new NotFoundException($"Não existe posição para o ID {id}!");
            }

            return dados;
        }

        public List<PosicaoVeiculoViewModel> Listar(int idVeiculo, DateTime? dataInicio, DateTime? dataFim = null)
        {
            if (!dataInicio.HasValue && dataFim.HasValue)
            {
                throw new AikoException("Informe a data inicial.");
            }

            if (dataInicio.HasValue && dataFim.HasValue && dataInicio > dataFim)
            {
                throw new AikoException("A data inicial deve ser menor que a final.");
            }

            if (!dataInicio.HasValue)
            {
                dataInicio = DateTime.Now;
            }

            var dados = repository.Listar(idVeiculo, dataInicio.Value, dataFim);

            if (dados.Any())
            {
                return dados;
            }

            throw new NotFoundException($"Não foram encontradas posições para o veículo de ID {idVeiculo} para o período informado.");
        }

        public void Cadastrar(PosicaoVeiculoViewModel dados)
        {
            VerificarObrigatorio(dados);

            repository.Cadastrar(dados);
        }

        public void Alterar(PosicaoVeiculoViewModel dados)
        {
            VerificarObrigatorio(dados);

            repository.Alterar(dados);
        }

        public void Excluir(int id)
        {
            repository.Excluir(id);
        }


        private void VerificarObrigatorio(PosicaoVeiculoViewModel dados)
        {
            if (dados.Veiculo.Id == 0
                || dados.Latitude == 0.0
                || dados.Longitude == 0.0)
            {
                throw new AikoException("Os campos ID do veículo, latitude e longitude são obrigatórios.");
            }
        }
    }
}
