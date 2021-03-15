using System.ComponentModel.DataAnnotations;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class VeiculoDTO

    {
        public long Id { get; set; }

        [Required (ErrorMessage="O Nome do veiculo é obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage="O Modelo do veiculo é obrigatório")]
        public string Modelo { get; set; }
        
        public long LinhaId { get; set; }

        public PosicaoVeiculoDTO PosicaoVeiculo { get; set; }
    }

    public class VeiculosLinhaDTO
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Modelo { get; set; }
    }
}
