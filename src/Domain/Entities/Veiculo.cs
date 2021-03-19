using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Veiculo
    {
        protected Veiculo()
        {
        }

        public Veiculo(string nome, string modelo, Localizacao localizacao, long id = 0)
        {
            Id = id;
            Nome = nome;
            Modelo = modelo;
            Localizacao = localizacao;
        }

        public long Id { get; set; }
        public string Nome { get; private set; }
        public string Modelo { get; private set; }
        public Linha Linha { get; private set; }
        public Localizacao Localizacao { get; private set; }
    }
}