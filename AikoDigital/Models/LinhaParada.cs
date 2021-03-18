using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AikoDigital.Models
{
    public class LinhaParada
    {
        [Key]

        public long LinhaId { get; set; }
        public Linha Linha { get; set; }
        public long ParadaId { get; set; }
        public Parada Parada { get; set; }
    }
}
