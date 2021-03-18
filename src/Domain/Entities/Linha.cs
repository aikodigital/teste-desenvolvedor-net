using System.Collections.Generic;
using System.Linq;

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

        public void AdicionarParada(Parada parada)
        {
            Paradas.Add(parada);
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void DesvincularVeiculo(long veiculoId)
        {
            var veiculo = Veiculos.FirstOrDefault(x => x.Id == veiculoId);

            Veiculos.Remove(veiculo);
        }

        public void DesvincularParada(long paradaId)
        {
            var parada = Paradas.FirstOrDefault(x => x.Id == paradaId);

            Paradas.Remove(parada);
        }
    }
}