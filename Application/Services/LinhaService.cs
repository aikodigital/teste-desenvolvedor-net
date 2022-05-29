using Application.Exceptions;
using Application.Repositories;
using Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class LinhaService
    {
        private readonly ILinhaRepository repository;
        private readonly ILinhaParadaRepository relRepository;

        public LinhaService(ILinhaRepository repository, ILinhaParadaRepository relRepository)
        {
            this.repository = repository;
            this.relRepository = relRepository;
        }

        public List<IdNomeViewModel> ListarPorParada(int idParada)
        {
            var dados = relRepository.ListarLinhaPorParada(idParada);

            if (dados.Any())
            {
                return dados;
            }

            throw new NotFoundException($"Não foram encontradas linhas para a parada de ID é {idParada}.");
        }

        public IdNomeViewModel Consultar(int id)
        {
            if (id == 0)
            {
                throw new AikoException($"Informe o identificador!");
            }

            var dados = repository.Consultar(id);
            if (dados == null)
            {
                throw new NotFoundException($"Não existe linha para o ID {id}!");
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

            throw new NotFoundException($"Não foram encontradas linhas.");
        }

        public void Cadastrar(IdNomeViewModel dados)
        {
            VerificarObrigatorio(dados);

            VerificarJaExiste(dados.Nome);

            repository.Cadastrar(dados);
        }

        public void Alterar(IdNomeViewModel dados)
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
                throw new AikoException($"Não existe linha com o ID {id}.");
            }

            repository.Alterar(dados, false);
        }


        private void VerificarObrigatorio(IdNomeViewModel dados)
        {
            if (string.IsNullOrWhiteSpace(dados.Nome))
            {
                throw new AikoException("O campo nome é obrigatório.");
            }
        }

        private void VerificarJaExiste(string nome, int id = 0)
        {
            var dadoExistente = repository.Consultar(nome);
            if (dadoExistente != null && dadoExistente.Id != id)
            {
                throw new AikoException($"Já existe uma linha cadastrada com o nome {nome}.");
            }
        }
    }
}
