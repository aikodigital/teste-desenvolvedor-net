
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.Domain.Entity.LinhasParadas
{
    public interface ILinhaParadaRepository
    {
        Task<bool> Associate(LinhaParada linhaParada);
        Task<bool> Disassociate(LinhaParada linhaParada);
        Task<IEnumerable<Linha>> GetLinhasByParada(long paradaId);
        Task<IEnumerable<LinhaParada>> GetAllLinhasParadas();
    }
}