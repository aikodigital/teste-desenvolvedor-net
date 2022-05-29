using Application.Exceptions;
using Application.Repositories;
using Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ParadaService
    {
        private readonly IParadaRepository repository;

        public ParadaService(IParadaRepository repository)
        {
            this.repository = repository;
        }

        public ParadaViewModel Consultar(int id)
        {
            if (id == 0)
            {
                throw new AikoException($"Informe o identificador!");
            }

            var dados = repository.Consultar(id);
            if (dados == null)
            {
                throw new NotFoundException($"Não existe parada para o ID {id}!");
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

            throw new NotFoundException($"Não foram encontradas paradas.");
        }

        public List<ParadaViewModel> ListarPorPosicao(double latitude, double longitude, int quantidade)
        {
            if (latitude == 0.0
                || longitude == 0.0
                || quantidade == 0)
            {
                throw new AikoException("Os campos quantidade de paradas, latitude e longitude são obrigatórios.");
            }

            var dados = repository.ListarPorPosicao(latitude, longitude, quantidade);

            if (dados.Any())
            {
                return dados;
            }

            throw new NotFoundException($"Não foram encontradas paradas.");
        }

        public void Cadastrar(ParadaViewModel dados)
        {
            VerificarObrigatorio(dados);

            VerificarJaExiste(dados.Nome);

            repository.Cadastrar(dados);
        }

        public void Alterar(ParadaViewModel dados)
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
                throw new AikoException($"Não existe parada com o ID {id}.");
            }

            repository.Alterar(dados, false);
        }


        private void VerificarObrigatorio(ParadaViewModel dados)
        {
            if (string.IsNullOrWhiteSpace(dados.Nome)
                || dados.Latitude == 0.0
                || dados.Longitude == 0.0)
            {
                throw new AikoException("Os campos nome, latitude e longitude são obrigatórios.");
            }
        }

        private void VerificarJaExiste(string nome, int id = 0)
        {
            var dadoExistente = repository.Consultar(nome);
            if (dadoExistente != null && dadoExistente.Id != id)
            {
                throw new AikoException($"Já existe uma parada cadastrada com o nome {nome}.");
            }
        }
    }
}
