using Microsoft.EntityFrameworkCore;
using Server_TransSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_TransSP.Data
{
    public class VeiculoContext : DbContext //Contexto que irá encapsular todas as entidades
    {
        public DbSet<LinhaModel> Linhas { get; set; }
        public DbSet<ParadaModel> Paradas { get; set; }
        public DbSet<PosicaoVeiculoModel> PosicaoVeiculos { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Data Source=Teste_Aiko");
        }
    }
}
