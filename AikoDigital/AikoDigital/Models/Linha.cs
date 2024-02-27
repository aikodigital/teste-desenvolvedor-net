using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AikoDigital.Models
{
    public class Linha
    {
        public Linha()
        {
            Paradas = new Collection<LinhaParada>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string? Name { get; set; }
        
        public ICollection<LinhaParada> Paradas { get; set; }
    }
}
