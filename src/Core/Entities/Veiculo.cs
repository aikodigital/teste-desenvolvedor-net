using Core.ValueObjects;

namespace Core.Entities
{
    public class Veiculo
    {
        protected Veiculo()
        {
        }

        public Veiculo(string name, string modelo, Localizacao localizacao, long id = 0)
        {
            Id = id;
            Name = name;
            Modelo = modelo;
            Localizacao = localizacao;
        }

        public long Id { get; set; }
        public string Name { get; private set; }
        public string Modelo { get; private set; }
        public Linha Linha { get; private set; }
        public Localizacao Localizacao { get; private set; }
    }
}