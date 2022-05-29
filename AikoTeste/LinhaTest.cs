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
using System.Reflection;

namespace AikoTeste
{
    public class LinhaTest
    {
        private readonly LinhaController service;

        public LinhaTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<LinhaController>();
            serviceCollection.AddTransient<LinhaService>();
            serviceCollection.AddTransient<ILinhaRepository, LinhaRepository>();
            serviceCollection.AddTransient<ILinhaParadaRepository, LinhaParadaRepository>();
            serviceCollection.AddDbContext<EFApplicationContext>(options =>
            {
                options.UseNpgsql(Constant.ConnectionString);
                EFApplicationContext.ConfigurationsAssembly = Assembly.GetExecutingAssembly();
            });

            var provider = serviceCollection.BuildServiceProvider();
            service = provider.GetService<LinhaController>();
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
        public void ListarPorParada()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.ListarPorParada(1)).Value;

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
                var retorno = (SaidaViewModel)((OkObjectResult)service.Cadastar(new IdNomeViewModel
                {
                    Nome = "Linha 4",
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
                var retorno = (SaidaViewModel)((OkObjectResult)service.Alterar(new IdNomeViewModel
                {
                    Id = 1,
                    Nome = "Linha 1B"
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
