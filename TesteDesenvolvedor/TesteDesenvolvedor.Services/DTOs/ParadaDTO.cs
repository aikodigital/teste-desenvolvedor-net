using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class ParadaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class ParadaPosicaoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distancia { get; set; }

    }

}
