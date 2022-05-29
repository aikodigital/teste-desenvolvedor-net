using System;

namespace Domain.Models
{
    public class PosicaoVeiculo
    {
        public int Id { get; set; }

        public int IdVeiculo { get; set; }

        public virtual Veiculo Veiculo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime DataPosicao { get; set; }
    }
}
