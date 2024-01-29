using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlhoVivo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedStops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Stops (Name, Latitude, Longitude, LineId) " +
                                     $"VALUES ('FREGUESIA C/B', -20.0001, 89.4521, 1)");

            migrationBuilder.Sql("INSERT INTO Stops (Name, Latitude, Longitude, LineId) " +
                                     $"VALUES ('AGARUM C/B', -59.1236, 159.6321, 1)");

            migrationBuilder.Sql("INSERT INTO Stops (Name, Latitude, Longitude, LineId) " +
                                     $"VALUES ('HANS CHRISTIAN ANDERSEN B/C', 57.3256, 27.26921, 1)");

            migrationBuilder.Sql("INSERT INTO Stops (Name, Latitude, Longitude, LineId) " +
                                     $"VALUES ('CRISTIAN ANDERSEN B/C', 71.2587, 145.2365, 2)");

            migrationBuilder.Sql("INSERT INTO Stops (Name, Latitude, Longitude, LineId) " +
                                     $"VALUES ('DOMÊNICO LAURO C/B', -86.2587, 135.9514, 2)");

            migrationBuilder.Sql("INSERT INTO Stops (Name, Latitude, Longitude, LineId) " +
                                     $"VALUES ('CAMISA VERDE E BRANCO - C/B', 15.2587, 75.5671, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Stops");
        }
    }
}
