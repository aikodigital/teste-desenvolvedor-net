using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public static class ModelBuilderExtension
    {
        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            DefinirDeleteBehaviorRestricParaTodasAsModels(modelBuilder);

            DefinirVarchar250ComoPadraoParaTodasColunasString(modelBuilder);
        }

        private static void DefinirVarchar250ComoPadraoParaTodasColunasString(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string))) {
                property.SetColumnType("varchar(250)");
            }
        }

        private static void DefinirDeleteBehaviorRestricParaTodasAsModels(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}