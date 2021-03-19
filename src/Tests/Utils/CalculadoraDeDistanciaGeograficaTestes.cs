using Services.Commons.Utils;
using Xunit;

namespace Tests.Utils
{
    public class CalculadoraDeDistanciaGeograficaTestes
    {
        private readonly CalculadoraDeDistanciaGeografica calculadoraDeDistanciaGeografica;

        public CalculadoraDeDistanciaGeograficaTestes()
        {
            calculadoraDeDistanciaGeografica = new CalculadoraDeDistanciaGeografica();
        }

        [Fact]
        public void DeveRetornarUmaDistanciaMenorQue500metros()
        {
            //assert
            var pos1 = new Domain.ValueObjects.Localizacao(
                    latitude: -8.771593,
                    longitude: -63.847208
            );

            var pos2 = new Domain.ValueObjects.Localizacao(
                    latitude: -8.76983,
                    longitude: -63.84870
            );

            //act
            var distancia = calculadoraDeDistanciaGeografica.HaversineDistance(pos1, pos2);

            //arrange
            Assert.True(distancia < 500);
        }

        [Fact]
        public void DeveRetornarUmaDistanciaMaiorQue500metros()
        {
            //assert
            var pos1 = new Domain.ValueObjects.Localizacao(
                    latitude: -8.771593,
                    longitude: -63.847208
            );

            var pos2 = new Domain.ValueObjects.Localizacao(
                    latitude: -8.77207,
                    longitude: -63.84177
            );

            //act
            var distancia = calculadoraDeDistanciaGeografica.HaversineDistance(pos1, pos2);

            //arrange
            Assert.True(distancia > 500);
        }
    }
}