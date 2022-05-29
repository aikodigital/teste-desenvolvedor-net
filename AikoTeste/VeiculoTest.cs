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
    public class VeiculoTest
    {
        private readonly VeiculoController service;

        public VeiculoTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<VeiculoController>();
            serviceCollection.AddTransient<VeiculoService>();
            serviceCollection.AddTransient<IVeiculoRepository, VeiculoRepository>();
            serviceCollection.AddTransient<IVeiculoLinhaRepository, VeiculoLinhaRepository>();
            serviceCollection.AddDbContext<EFApplicationContext>(options =>
            {
                options.UseNpgsql(Constant.ConnectionString);
                EFApplicationContext.ConfigurationsAssembly = Assembly.GetExecutingAssembly();
            });

            var provider = serviceCollection.BuildServiceProvider();
            service = provider.GetService<VeiculoController>();
        }

        [Test]
        public void Consultar()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.Consultar(1)).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Listar()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.Listar()).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void ListarPorLinha()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.ListarPorLinha(1, new DateTime(2022, 5, 20, 6, 0, 0), null)).Value;

                Assert.AreEqual(true, retorno.Sucesso && ((List<IdNomeViewModel>)retorno.Dados).Count == 2, retorno.Mensagem);
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
                var retorno = (SaidaViewModel)((OkObjectResult)service.Cadastar(new VeiculoViewModel
                {
                    Nome = "3131",
                    Modelo = "Mercedes-Benz"
                })).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Alterar()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.Alterar(new VeiculoViewModel
                {
                    Id = 1,
                    Nome = "7745B",
                    Modelo = "Volvo"
                })).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Excluir()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.Excluir(2)).Value;

                Assert.AreEqual(true, retorno.Sucesso, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
