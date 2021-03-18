using System.ComponentModel.DataAnnotations.Schema;

namespace AikoDigital.Models
{
    public class Veiculo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Modelo { get; set; }
        public long LinhaId { get; set; }
        public Linha Linha { get; set; }
    }
}
