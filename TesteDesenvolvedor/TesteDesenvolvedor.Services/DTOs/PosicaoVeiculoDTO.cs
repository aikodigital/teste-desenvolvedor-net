using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class PosicaoVeiculoDTO
    {
        [Required(ErrorMessage = "A latitude é obrigatória")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude é obrigatório")]
        public double Longitude { get; set; }

        [Required (ErrorMessage="O ID do Veiculo é obrigatório")]
        public long VeiculoID { get; set; }
    }
}
