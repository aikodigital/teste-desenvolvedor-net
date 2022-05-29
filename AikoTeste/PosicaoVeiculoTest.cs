using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AikoTeste
{
    public class PosicaoVeiculoTest
    {
        private readonly PosicaoVeiculoController service;

        public PosicaoVeiculoTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<PosicaoVeiculoController>();
            serviceCollection.AddTransient<PosicaoVeiculoService>();
            serviceCollection.AddTransient<IPosicaoVeiculoRepository, PosicaoVeiculoRepository>();
            serviceCollection.AddDbContext<EFApplicationContext>(options =>
            {
                options.UseNpgsql(Constant.ConnectionString);
                EFApplicationContext.ConfigurationsAssembly = Assembly.GetExecutingAssembly();
            });

            var provider = serviceCollection.BuildServiceProvider();
            service = provider.GetService<PosicaoVeiculoController>();
        }

        [Test]
        public void Listar()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.ListarPorVeiculo(1, null, null)).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Cadastrar()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.Cadastar(new PosicaoVeiculoViewModel
                {
                    DataPosicao = DateTime.Now,
                    Latitude = -21.2306215,
                    Longitude = -45.0076261,
                    Veiculo = new IdNomeViewModel { Id = 1 }
                })).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
