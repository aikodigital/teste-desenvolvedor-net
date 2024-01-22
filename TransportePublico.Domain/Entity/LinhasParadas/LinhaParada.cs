
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.Domain.Entity.LinhasParadas
{
    public class LinhaParada
    {
        public long LinhaParadaId { get; set;}
        public long LinhaId { get; set; }
        public long ParadaId { get; set; }
        public virtual Linha? Linha { get; set; }
        public virtual Parada? Parada { get; set; }

        public LinhaParada(long linhaId, long paradaId)
        {
            LinhaId = linhaId;
            ParadaId = paradaId;
        }
    }
}