using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Domain
{
    public class PosicaoVeiculo
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
