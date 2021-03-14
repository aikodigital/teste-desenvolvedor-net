using System.Collections.Generic;
using Domain.ValueObjects;

namespace Domain.Entities
{
	public class Linha
	{
		public Linha(string nome, long id = 0)
		{
			Id = id;
			Nome = nome;
            Veiculos = new List<Veiculo>();
			Paradas = new List<Parada>();
		}
		public long Id { get; private set; }
		public string Nome { get; private set; }
        public ICollection<Veiculo> Veiculos { get; private set; }
        public ICollection<Parada> Paradas { get; private set; }

		public void AdicionarParada(string nome, Localizacao localizacao)
		{
			Paradas.Add(new Parada(nome, localizacao));
		}
	}
}
