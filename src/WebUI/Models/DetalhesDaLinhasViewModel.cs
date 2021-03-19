using System.Collections.Generic;

namespace WebUI.Models
{
    public class DetalhesDaLinhasViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<VeiculoViewModel> Veiculos { get; set; }
        public ICollection<ParadaViewModel> Paradas { get; set; }
    }
}