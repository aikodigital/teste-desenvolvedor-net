using TransportePublico.App.Queries.Linhas;
using TransportePublico.App.Queries.Paradas;
namespace TransportePublico.App.Queries.LinhasParadas
{
    public class LinhaParadaDto
    {
        public long LinhaId { get; set; }
        public long ParadaId { get; set; }
        public ParadaDto? Parada { get; set; }
        public LinhaDto? Linha { get; set; }
    }
}