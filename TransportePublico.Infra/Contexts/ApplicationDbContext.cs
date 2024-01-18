using Microsoft.EntityFrameworkCore;
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Domain.Entity.LinhasParadas;
using TransportePublico.Domain.Entity.Paradas;
using TransportePublico.Domain.Entity.PosicoesVeiculos;
using TransportePublico.Domain.Entity.Veiculos;
#nullable disable
namespace TransportePublico.Infra.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Linha> Linhas { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<PosicaoVeiculo> PosicoesVeiculos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<LinhaParada> LinhasParadas { get; set; }
    }
}