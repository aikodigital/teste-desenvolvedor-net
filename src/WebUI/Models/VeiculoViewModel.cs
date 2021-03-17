namespace WebUI.Models
{
    public class VeiculoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public LocalizacaoDto Localizacao { get; set; }
    }
}