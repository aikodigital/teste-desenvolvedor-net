using System;

namespace Domain.Models
{
    public class RelVeiculoLinha
    {
        public int Id { get; set; }

        public int IdVeiculo { get; set; }

        public virtual Veiculo Veiculo { get; set; }

        public int IdLinha { get; set; }

        public virtual Linha Linha { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}
