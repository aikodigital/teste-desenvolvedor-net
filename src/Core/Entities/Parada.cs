using Core.ValueObjects;

namespace Core.Entities
{
    public class Parada
    {
        protected Parada()
        {
        }

        public Parada(string name, Localizacao localizacao, long id = 0)
        {
            Id = id;
            Name = name;
            Localizacao = localizacao;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public Localizacao Localizacao { get; private set; }
    }
}