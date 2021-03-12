using System.Collections.Generic;
using Core.ValueObjects;

namespace Core.Entities
{
	public class Linha
	{
		public Linha(string name, long id = 0)
		{
			Id = id;
			Name = name;
			Paradas = new List<Parada>();
		}
		public long Id { get; private set; }
		public string Name { get; private set; }
		public ICollection<Parada> Paradas { get; private set; }

		public void AdicionarParada(string nome, Localizacao localizacao)
		{
			Paradas.Add(new Parada(nome, localizacao));
		}
	}
}
