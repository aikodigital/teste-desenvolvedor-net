using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IVeiculoRepository
    {
        VeiculoViewModel Consultar(int id);

        VeiculoViewModel Consultar(string nome);

        List<IdNomeViewModel> Listar(bool somenteAtivos = true);

        void Cadastrar(VeiculoViewModel dados);

        void Alterar(VeiculoViewModel dados, bool ativo = true);
    }
}
