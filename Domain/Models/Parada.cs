using System.Collections.Generic;

namespace Domain.Models
{
    public class Parada
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool Ativo { get; set; }
    }
}
