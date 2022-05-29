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
using System.Linq;
using System.Reflection;

namespace AikoTeste
{
    public class ParadaTest
    {
        private readonly ParadaController service;

        public ParadaTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ParadaController>();
            serviceCollection.AddTransient<ParadaService>();
            serviceCollection.AddTransient<IParadaRepository, ParadaRepository>();
            serviceCollection.AddDbContext<EFApplicationContext>(options =>
            {
                options.UseNpgsql(Constant.ConnectionString);
                EFApplicationContext.ConfigurationsAssembly = Assembly.GetExecutingAssembly();
            });

            var provider = serviceCollection.BuildServiceProvider();
            service = provider.GetService<ParadaController>();
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
        public void ListarPorPosicao()
        {
            try
            {
                var retorno = (SaidaViewModel)((OkObjectResult)service.ListarPorPosicao(-21.232639601352375, -45.00846872620024, 3)).Value;

                var dados = (List<ParadaViewModel>)retorno.Dados;

                Assert.AreEqual(true, retorno.Sucesso  && dados.Count == 3 && dados.First().Id == 5, retorno.Mensagem);
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
                var retorno = (SaidaViewModel)((OkObjectResult)service.Cadastar(new ParadaViewModel
                {
                    Nome = "Parada 13",
                    Latitude = -21.2306215,
                    Longitude = -45.0076261
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
                var retorno = (SaidaViewModel)((OkObjectResult)service.Alterar(new ParadaViewModel
                {
                    Id = 1,
                    Nome = "Parada 1B",
                    Latitude = -21.226306477717028,
                    Longitude = -45.009879848010776
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
