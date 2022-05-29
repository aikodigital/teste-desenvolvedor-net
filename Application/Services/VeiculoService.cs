using Application.Exceptions;
using Application.Repositories;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class VeiculoService
    {
        private readonly IVeiculoRepository repository;
        private readonly IVeiculoLinhaRepository relRepository;

        public VeiculoService(IVeiculoRepository repository, IVeiculoLinhaRepository relRepository)
        {
            this.repository = repository;
            this.relRepository = relRepository;
        }

        public List<IdNomeViewModel> ListarPorLinha(int idLinha, DateTime? dataInicio, DateTime? dataFim)
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
            
            var dados = relRepository.ListarVeiculoPorLinha(idLinha, dataInicio.Value, dataFim);

            if (dados.Any())
            {
                return dados;
            }

            throw new NotFoundException($"Não foram encontrados veículos para a linha de ID {idLinha}.");
        }

        public VeiculoViewModel Consultar(int id)
        {
            if (id == 0)
            {
                throw new AikoException($"Informe o identificador!");
            }

            var dados = repository.Consultar(id);
            if (dados == null)
            {
                throw new NotFoundException($"Não existe veículo para o ID {id}!");
            }

            return dados;
        }

        public List<IdNomeViewModel> Listar(bool somenteAtivos = true)
        {
            var dados = repository.Listar(somenteAtivos);

            if (dados.Any())
            {
                return dados;
            }

            throw new NotFoundException($"Não foram encontrados veículos.");
        }

        public void Cadastrar(VeiculoViewModel dados)
        {
            VerificarObrigatorio(dados);

            VerificarJaExiste(dados.Nome);

            repository.Cadastrar(dados);
        }

        public void Alterar(VeiculoViewModel dados)
        {
            VerificarObrigatorio(dados);

            VerificarJaExiste(dados.Nome, dados.Id);

            repository.Alterar(dados);
        }

        public void Excluir(int id)
        {
            var dados = repository.Consultar(id);
            if (dados == null)
            {
                throw new AikoException($"Não existe veículo com o ID {id}.");
            }

            repository.Alterar(dados, false);
        }


        private void VerificarObrigatorio(VeiculoViewModel dados)
        {
            if (string.IsNullOrWhiteSpace(dados.Nome)
                || string.IsNullOrWhiteSpace(dados.Modelo))
            {
                throw new AikoException("Os campos nome e modelo são obrigatórios.");
            }
        }

        private void VerificarJaExiste(string nome, int id = 0)
        {
            var dadoExistente = repository.Consultar(nome);
            if (dadoExistente != null && dadoExistente.Id != id)
            {
                throw new AikoException($"Já existe um veículo cadastrado com o nome {nome}.");
            }
        }
    }
}
