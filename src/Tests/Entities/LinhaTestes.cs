using Core.Entities;
using Core.ValueObjects;
using Xunit;

namespace Tests.Entities
{
	public class LinhaTestes
	{
		[Fact]
		public void DeveAdicionarUmaParada()
		{
			//arrange
			var linha = new Linha(name: "linha 1");

			//act
			linha.AdicionarParada("primeira parada", localizacao: new Localizacao(latitude: 123456, longitude: 654321));

			//assert

			Assert.True(linha.Paradas.Count == 1);
		}

		[Fact]
		public void NaoDeveAdicionarUmaParada()
		{
			//arrange
			var linha = new Linha(name: "linha 1");

			//act
			linha.AdicionarParada("primeira parada", localizacao: new Localizacao(latitude: 123456, longitude: 654321));

			//assert

			Assert.True(linha.Paradas.Count == 1);
		}
	}
}
