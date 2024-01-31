using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicTransportation.Infra.Migrations
{
    public partial class addedseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Line",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "6030-10 UNISA-CAMPUS 1 / TERM. STO. AMARO" });

            migrationBuilder.InsertData(
                table: "Stop",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1L, -23.742760700000002, -46.711070300000003, "AV. CARLOS OBERHUBER" },
                    { 2L, -23.743522299999999, -46.705872800000002, "PÇA. JOSÉ BOEMER ROSCHEL" },
                    { 3L, -23.737659600000001, -46.704855799999997, "R. RUBEM SOUTO DE ARAÚJO" },
                    { 4L, -23.482340000000001, -46.429929999999999, "R. MANOEL DE LIMA" },
                    { 5L, -23.59976, -46.854460000000003, "R. INDOCHINA" },
                    { 6L, -23.727979999999999, -46.711390000000002, "R. JOSÉ LUÍS MONTEIRO" },
                    { 7L, -23.729880000000001, -46.708849999999998, "R. CAROLINA MICHAELIS" },
                    { 8L, -23.732389999999999, -46.708860000000001, "R. PROF. ENÉAS DE SIQUEIRA NETO" },
                    { 9L, -23.62613, -46.689399999999999, "R. JOSÉ SOLANA" },
                    { 10L, -23.725549999999998, -46.712060000000001, "R. FREDERICO RENÉ DE JAEGHER" },
                    { 11L, -23.276689999999999, -47.277200000000001, "AV. SEN. TEOTÔNIO VILELA" },
                    { 12L, -23.598839999999999, -46.693460000000002, "AV. DAS NAÇÕES UNIDAS (MARGINAL PINHEIROS)" },
                    { 13L, -23.664940000000001, -46.706569999999999, "R. CRISTALINO ROLIM DE FREITAS" },
                    { 14L, -23.664870000000001, -46.705190000000002, "R. OTÁVIO CASTRO FILHO" },
                    { 15L, -23.669229999999999, -46.703290000000003, "R. GALENO DE CASTRO" },
                    { 16L, -23.663060000000002, -46.707520000000002, "AV. VÍTOR MANZINI" },
                    { 17L, -23.66113, -46.705739999999999, "PÇA. D. FRANCISCO DE SOUZA" },
                    { 18L, -23.55049, -46.639069999999997, "AL. STO. AMARO" },
                    { 19L, -23.652339999999999, -46.707819999999998, "R. PAULO EIRÓ" },
                    { 20L, -23.654730000000001, -46.71293, "AV. PE. JOSÉ MARIA" }
                });

            migrationBuilder.InsertData(
                table: "LineStop",
                columns: new[] { "Id", "LineId", "StopId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 1L, 2L },
                    { 3L, 1L, 3L },
                    { 4L, 1L, 4L },
                    { 5L, 1L, 5L },
                    { 6L, 1L, 6L },
                    { 7L, 1L, 7L },
                    { 8L, 1L, 8L },
                    { 9L, 1L, 9L },
                    { 10L, 1L, 10L },
                    { 11L, 1L, 11L },
                    { 12L, 1L, 12L },
                    { 13L, 1L, 13L },
                    { 14L, 1L, 14L },
                    { 15L, 1L, 15L },
                    { 16L, 1L, 16L },
                    { 17L, 1L, 17L },
                    { 18L, 1L, 18L },
                    { 19L, 1L, 19L },
                    { 20L, 1L, 20L }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "LineId", "Model", "Name" },
                values: new object[] { 1L, 1L, "Torino", "Marcopolo Torino" });

            migrationBuilder.InsertData(
                table: "VehiclePosition",
                columns: new[] { "Id", "Latitude", "Longitude", "VehicleId" },
                values: new object[] { 1L, -23.742760700000002, -46.711070300000003, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "LineStop",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "VehiclePosition",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Stop",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Line",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
