using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace AikoDigital.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Linha> Linhas { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set;}
        public DbSet<PosicaoVeiculo> PosicaoVeiculos { get; set; }

        public DbSet<LinhaParada> LinhaParadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Linha)
                .WithMany()
                .HasForeignKey(v => v.LinhaId);

            modelBuilder.Entity<LinhaParada>()
                .HasKey(lp => new { lp.LinhaId, lp.ParadaId });

            modelBuilder.Entity<LinhaParada>()
                .HasOne(lp => lp.Linhas)
                .WithMany(l => l.Paradas)
                .HasForeignKey(lp => lp.LinhaId);

            modelBuilder.Entity<LinhaParada>()
                .HasOne(lp => lp.Paradas)
                .WithMany(p => p.Linhas)
                .HasForeignKey(lp => lp.ParadaId);
        }
    }
}
