using TransportePublico.App.Queries.Linhas;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.App.Queries.Veiculos
{
    [AutoMapper.AutoMap(typeof(Veiculo), ReverseMap = true)]
    public class VeiculoDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Modelo { get; set; }
        public long LinhaId { get; set; }
        public LinhaDto? Linha { get; set; }
    }
}