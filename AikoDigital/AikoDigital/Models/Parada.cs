using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoDigital.Models
{
    public class Parada
    {
        public Parada()
        {
            Linhas = new Collection<LinhaParada>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public ICollection<LinhaParada> Linhas { get; set; }
    }
}
