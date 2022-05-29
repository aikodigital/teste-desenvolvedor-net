using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface ILinhaParadaRepository
    {
        List<IdNomeViewModel> ListarLinhaPorParada(int idParada);
    }
}
