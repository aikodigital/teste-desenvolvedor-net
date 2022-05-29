using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface ILinhaRepository
    {
        IdNomeViewModel Consultar(int id);

        IdNomeViewModel Consultar(string nome);

        List<IdNomeViewModel> Listar(bool somenteAtivos = true);

        void Cadastrar(IdNomeViewModel dados);

        void Alterar(IdNomeViewModel dados, bool ativo = true);
    }
}
