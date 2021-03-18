using System.Threading.Tasks;
using Services.Commons.Utils;
using Services.Parada;
using Xunit;

namespace Tests.ServicesTestes
{
    public class ParadaServiceTestes : BaseTeste
    {
        private readonly ListarParadasMaisProximas listarParadasMaisProximas;
        private readonly CalculadoraDeDistanciaGeografica calculadoraDeDistanciaGeografica;

        public ParadaServiceTestes()
        {
            calculadoraDeDistanciaGeografica = new CalculadoraDeDistanciaGeografica();
            listarParadasMaisProximas = new ListarParadasMaisProximas(context, calculadoraDeDistanciaGeografica);
        }

        [Fact]
        public async Task DeveListarAsParadasMaisProximasEmUmRaioDe500Metros()
        {
            //arrange
            var parada1 = new Domain.Entities.Parada(
                 nome: "Parada 1",
                 new Domain.ValueObjects.Localizacao(
                    latitude: -8.771593,
                    longitude: -63.847208
                 )
            );

            var parada2 = new Domain.Entities.Parada(
                nome: "Parada 2",
                new Domain.ValueObjects.Localizacao(
                    latitude: -8.76983,
                    longitude: -63.84870
                )
           );

            var parada3 = new Domain.Entities.Parada(
                nome: "Parada 3",
                new Domain.ValueObjects.Localizacao(
                    latitude: -8.76832,
                    longitude: -63.84265
                )
            );

            var parada4 = new Domain.Entities.Parada(
                nome: "Parada 4",
                new Domain.ValueObjects.Localizacao(
                    latitude: -8.77207,
                    longitude: -63.84177
                )
            );

            await context.AddAsync(parada1);
            await context.AddAsync(parada2);
            await context.AddAsync(parada3);
            await context.AddAsync(parada4);
            await context.SaveChangesAsync();

            //act
            var paradasMaisProximas = await listarParadasMaisProximas.Executar(latitude: -8.771593, longitude: -63.847208, raioEmMetros: 500);

            //assert
            Assert.True(paradasMaisProximas.Count == 2);
            Assert.Contains(paradasMaisProximas, x => x.Nome == "Parada 1");
            Assert.Contains(paradasMaisProximas, x => x.Nome == "Parada 2");
        }
    }
}