using Domain.Entities;
using Domain.ValueObjects;
using Xunit;

namespace Tests.Entities
{
	public class LinhaTestes
	{
        private readonly Linha linha = new Linha(nome: "linha 1");
        private static readonly Localizacao localizacao = new Localizacao(latitude: 123456, longitude: 654321);
        private readonly Parada parada = new Parada("primeira parada", localizacao);
        private Veiculo veiculo = new Veiculo("ônibus", "mercedes", localizacao: localizacao);

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
