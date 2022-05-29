using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IVeiculoLinhaRepository
    {
        List<IdNomeViewModel> ListarVeiculoPorLinha(int idLinha, DateTime dataUnicaOuInicial, DateTime? dataFinal = null);
    }
}
