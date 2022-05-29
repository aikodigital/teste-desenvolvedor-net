using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application.Repositories
{
    public interface IPosicaoVeiculoRepository
    {
        PosicaoVeiculoViewModel Consultar(int id);

        List<PosicaoVeiculoViewModel> Listar(int idVeiculo, DateTime dataUnicaOuInicial, DateTime? dataFinal = null);

        void Cadastrar(PosicaoVeiculoViewModel dados);

        void Alterar(PosicaoVeiculoViewModel dados);

        void Excluir(int id);
    }
}
