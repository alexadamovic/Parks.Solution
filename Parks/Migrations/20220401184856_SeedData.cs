using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "State" },
                values: new object[,]
                {
                    { 1, "OR" },
                    { 2, "CO" },
                    { 3, "HI" },
                    { 4, "CA" }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "IsNationalPark", "IsStatePark", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, true, false, 1, "Crater Lake" },
                    { 8, false, true, 1, "Agate Beach" },
                    { 9, false, true, 1, "Tryon Creek" },
                    { 2, true, false, 2, "Black Canyon of the Gunnison" },
                    { 3, true, false, 2, "Mesa Verde" },
                    { 13, false, true, 2, "Sweitzer Lake" },
                    { 14, false, true, 2, "Roxborough" },
                    { 4, true, false, 3, "Haleakala" },
                    { 10, false, true, 3, "Wailua River" },
                    { 5, true, false, 4, "Joshua Tree" },
                    { 6, true, false, 4, "Death Valley" },
                    { 7, true, false, 4, "Yosemite" },
                    { 11, false, true, 4, "Moonlight Beach" },
                    { 12, false, true, 4, "San Bruno Mountain" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);
        }
    }
}
