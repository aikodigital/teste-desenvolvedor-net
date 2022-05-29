using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IParadaRepository
    {
        ParadaViewModel Consultar(int id);

        ParadaViewModel Consultar(string nome);

        List<IdNomeViewModel> Listar(bool somenteAtivos = true);

        List<ParadaViewModel> ListarPorPosicao(double latitude, double longitude, int quantidade);

        void Cadastrar(ParadaViewModel dados);

        void Alterar(ParadaViewModel dados, bool ativo = true);
    }
}
