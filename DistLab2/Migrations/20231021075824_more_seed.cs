using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class more_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate", "Username" },
                values: new object[] { new DateTime(2023, 10, 21, 9, 58, 24, 417, DateTimeKind.Local).AddTicks(6093), new DateTime(2024, 10, 21, 9, 58, 24, 417, DateTimeKind.Local).AddTicks(6125), "agge@hotmail.com" });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "CreationDate", "Description", "EndDate", "Name", "StartingPrice", "Username" },
                values: new object[] { -2, new DateTime(2023, 10, 21, 9, 58, 24, 417, DateTimeKind.Local).AddTicks(6190), "Min andra auktion", new DateTime(2023, 10, 21, 9, 48, 24, 417, DateTimeKind.Local).AddTicks(6192), "Auction2", 100, "agge@hotmail.com" });

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

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "DateOfBid", "Username" },
                values: new object[,]
                {
                    { -4, -2, 5800.0, new DateTime(2023, 10, 21, 9, 38, 24, 417, DateTimeKind.Local).AddTicks(6196), "Albin" },
                    { -3, -2, 501.0, new DateTime(2023, 10, 21, 9, 18, 24, 417, DateTimeKind.Local).AddTicks(6194), "Emil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate", "Username" },
                values: new object[] { new DateTime(2023, 10, 19, 16, 36, 33, 681, DateTimeKind.Local).AddTicks(7545), new DateTime(2024, 10, 19, 16, 36, 33, 681, DateTimeKind.Local).AddTicks(7579), "Algot" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 19, 16, 56, 33, 681, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 19, 16, 46, 33, 681, DateTimeKind.Local).AddTicks(7708));
        }
    }
}
