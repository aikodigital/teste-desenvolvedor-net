using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransport.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclePositions",
                table: "VehiclePositions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclePositions",
                table: "VehiclePositions",
                column: "VehiclePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePositions_VehicleId",
                table: "VehiclePositions",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclePositions",
                table: "VehiclePositions");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePositions_VehicleId",
                table: "VehiclePositions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclePositions",
                table: "VehiclePositions",
                column: "VehicleId");
        }
    }
}
