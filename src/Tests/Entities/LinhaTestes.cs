using Domain.Entities;
using Domain.ValueObjects;
using Xunit;

namespace Tests.Entities
{
    public class LinhaTestes
	{
        private readonly static Localizacao localizacao = new(latitude: 123456, longitude: 654321);
        private readonly Linha linha = new(nome: "linha 1");
        private readonly Parada parada = new("primeira parada", localizacao);
        private readonly Veiculo veiculo = new("ônibus", "mercedes", localizacao: localizacao);

        [Fact]
		public void DeveAdicionarUmaParada()
		{
			//act
			linha.AdicionarParada(parada);

			//assert

			Assert.True(linha.Paradas.Count == 1);
		}

		[Fact]
		public void DeveAdicionarUmVeiculo()
		{
			//act
			linha.AdicionarVeiculo(veiculo);

			//assert

			Assert.True(linha.Veiculos.Count == 1);
		}
	}
}
