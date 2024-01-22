using TransportePublico.App.Queries.Linhas;

namespace TransportePublico.App.Queries.Veiculos
{
    public class VeiculoDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Modelo { get; set; }
        public long LinhaId { get; set; }
        public LinhaDto? Linha { get; set; }
    }
}