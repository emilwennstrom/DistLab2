using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class won_auction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 22, 12, 18, 57, 944, DateTimeKind.Local).AddTicks(5765), new DateTime(2023, 10, 22, 12, 8, 57, 944, DateTimeKind.Local).AddTicks(5767) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 22, 12, 18, 57, 944, DateTimeKind.Local).AddTicks(5675), new DateTime(2024, 10, 22, 12, 18, 57, 944, DateTimeKind.Local).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 22, 11, 58, 57, 944, DateTimeKind.Local).AddTicks(5772), "algot@kth.se" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 11, 38, 57, 944, DateTimeKind.Local).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 12, 38, 57, 944, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 12, 28, 57, 944, DateTimeKind.Local).AddTicks(5708));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 21, 9, 58, 24, 417, DateTimeKind.Local).AddTicks(6190), new DateTime(2023, 10, 21, 9, 48, 24, 417, DateTimeKind.Local).AddTicks(6192) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 21, 9, 58, 24, 417, DateTimeKind.Local).AddTicks(6093), new DateTime(2024, 10, 21, 9, 58, 24, 417, DateTimeKind.Local).AddTicks(6125) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 21, 9, 38, 24, 417, DateTimeKind.Local).AddTicks(6196), "Albin" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 21, 9, 18, 24, 417, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 21, 10, 18, 24, 417, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 21, 10, 8, 24, 417, DateTimeKind.Local).AddTicks(6128));
        }
    }
}
