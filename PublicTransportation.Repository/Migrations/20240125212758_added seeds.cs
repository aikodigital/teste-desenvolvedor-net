using Microsoft.EntityFrameworkCore.Migrations;

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
                    { 3L, -23.737659600000001, -46.704855799999997, "R. RUBEM SOUTO DE ARAÚJO" }
                });

            migrationBuilder.InsertData(
                table: "LineStop",
                columns: new[] { "Id", "LineId", "StopId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 1L, 2L },
                    { 3L, 1L, 3L }
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
