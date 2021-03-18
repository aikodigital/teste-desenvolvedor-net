using System.ComponentModel.DataAnnotations.Schema;

namespace AikoDigital.Models
{
    public class PosicaoVeiculo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
