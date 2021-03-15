using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class LinhasPorParada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paradas_Linhas_LinhaId",
                table: "Paradas");

            migrationBuilder.DropIndex(
                name: "IX_Paradas_LinhaId",
                table: "Paradas");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Paradas");

            migrationBuilder.CreateTable(
                name: "LinhasPorParada",
                columns: table => new
                {
                    LinhaId = table.Column<long>(type: "bigint", nullable: false),
                    ParadaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhasPorParada", x => new { x.LinhaId, x.ParadaId });
                    table.ForeignKey(
                        name: "FK_LinhaParada_Linhas_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinhaParada_Paradas_ParadaId",
                        column: x => x.ParadaId,
                        principalTable: "Paradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinhasPorParada_ParadaId",
                table: "LinhasPorParada",
                column: "ParadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinhasPorParada");

            migrationBuilder.AddColumn<long>(
                name: "LinhaId",
                table: "Paradas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_LinhaId",
                table: "Paradas",
                column: "LinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paradas_Linhas_LinhaId",
                table: "Paradas",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
