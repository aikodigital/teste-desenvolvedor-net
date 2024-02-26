using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvedor.Domain
{
    public class Veiculo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public long LinhaId { get; set; }
        public Linha Linha { get; set; }
        public PosicaoVeiculo PosicaoVeiculo { get; set; }
    }
}
