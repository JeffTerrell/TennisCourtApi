using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisCourt.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "CourtId", "Address", "City", "Name", "Public", "State", "SurfaceType" },
                values: new object[,]
                {
                    { 3, "1111 Interlake N", "Seattle", "Seattle Tennis Club", true, "Washington", "Hard" },
                    { 4, "2314 Denny way N", "Fargo", "Fargo Community Center", true, "North Dakota", "Grass" },
                    { 5, "700 Rex st SE", "Portland", "Portland University Court", true, "Oregon", "Hard" },
                    { 6, "1245 Spokane Way N", "Spokane", "Spokane Court", true, "Washington", "Hard" },
                    { 7, "435 Lynn S", "San Francisco", "San Francisco Tennis Club", false, "California", "Clay" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "CourtId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "CourtId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "CourtId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "CourtId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "CourtId",
                keyValue: 7);
        }
    }
}
