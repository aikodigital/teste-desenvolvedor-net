using AikoDigital.DataContext.EntityConfigMap;
using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AikoDigital.DataContext
{
    public class ApiDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApiDataContext(DbContextOptions<ApiDataContext> options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Linha> Linhas { get; set; }
        public DbSet<PosicaoVeiculo> PosicaoVeiculos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<LinhaParada> LinhaParadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LinhaMap());
            modelBuilder.ApplyConfiguration(new ParadaMap());
            modelBuilder.ApplyConfiguration(new PosicaoVeiculoMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new LinhaParadaMap());
            base.OnModelCreating(modelBuilder);

        }

    }
}
