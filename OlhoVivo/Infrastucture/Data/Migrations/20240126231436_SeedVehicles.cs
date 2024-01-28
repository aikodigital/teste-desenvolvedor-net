using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlhoVivo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Vehicles (Name, Model, LineId) " +
                                     $"VALUES ('MICROÔNIBUS 1', 'MBB - SPRINTER 415CDI', 1)");

            migrationBuilder.Sql("INSERT INTO Vehicles (Name, Model, LineId) " +
                                     $"VALUES ('MINIÔMIBUS 2', 'MASCARELLO - MICRO CITY S3', 1)");

            migrationBuilder.Sql("INSERT INTO Vehicles (Name, Model, LineId) " +
                                     $"VALUES ('MIDIÔNIBUS 3', 'CAIO - APACHE - MBB OF-1519', 2)");
            
            migrationBuilder.Sql("INSERT INTO Vehicles (Name, Model, LineId) " +
                                     $"VALUES ('MIDIÔNIBUS 4', 'MASCARELLO - GRAN VIA - VW 17.260', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Vehicles");
        }
    }
}
