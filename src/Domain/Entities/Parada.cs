using System.Collections;
using System.Collections.Generic;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Parada
    {
        protected Parada()
        {
        }

        public Parada(string nome, Localizacao localizacao, long id = 0)
        {
            Id = id;
            Nome = nome;
            Localizacao = localizacao;
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public Localizacao Localizacao { get; private set; }
        public ICollection<Linha> Linhas { get; private set; }
    }
}