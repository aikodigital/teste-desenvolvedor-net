using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AikoDigital.Models
{
    public class Linha
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<LinhaParada> LinhaParadas { get; set; }
    }
}
