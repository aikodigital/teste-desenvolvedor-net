using Core.Entities;
using Core.ValueObjects;
using Xunit;

namespace Testes.Entities
{
	public class LinhaTestes
	{
		[Fact]
		public void DeveAdicionarUmaParada()
		{
			//arrange
			var linha = new Linha(name: "linha 1");
			linha.AdicionarParada("primeira parada", localizacao: new Localizacao(latitude: 123456, longitude: 654321));

			//act

			//assert

			Assert.True(false);
		}

		[Fact]
		public void NaoDeveAdicionarUmaParada()
		{
			Assert.True(false);
		}
	}
}
