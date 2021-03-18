using Microsoft.EntityFrameworkCore.Migrations;

namespace AikoDigital.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linhas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paradas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    LinhaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Linhas_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinhaParadas",
                columns: table => new
                {
                    LinhaId = table.Column<long>(nullable: false),
                    ParadaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaParadas", x => new { x.LinhaId, x.ParadaId });
                    table.ForeignKey(
                        name: "FK_LinhaParadas_Linhas_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinhaParadas_Paradas_ParadaId",
                        column: x => x.ParadaId,
                        principalTable: "Paradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosicaoVeiculos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    VeiculoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosicaoVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosicaoVeiculos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinhaParadas_ParadaId",
                table: "LinhaParadas",
                column: "ParadaId");

            migrationBuilder.CreateIndex(
                name: "IX_PosicaoVeiculos_VeiculoId",
                table: "PosicaoVeiculos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_LinhaId",
                table: "Veiculos",
                column: "LinhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinhaParadas");

            migrationBuilder.DropTable(
                name: "PosicaoVeiculos");

            migrationBuilder.DropTable(
                name: "Paradas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Linhas");
        }
    }
}
