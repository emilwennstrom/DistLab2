using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class Auctions_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "Description", "EndDate", "Name", "Username" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3525), "Jag hittade den", new DateTime(2023, 10, 24, 11, 11, 11, 995, DateTimeKind.Local).AddTicks(3529), "Plånbok", "algot@kth.com" });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "Description", "EndDate", "Name", "StartingPrice" },
                values: new object[] { new DateTime(2023, 10, 4, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3390), "lite hål dock", new DateTime(2023, 10, 23, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3425), "Fina hattar", 99 });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 24, 11, 1, 11, 995, DateTimeKind.Local).AddTicks(3536), "algot@hotmail.se" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 24, 10, 41, 11, 995, DateTimeKind.Local).AddTicks(3533), "emil@hotmale.com" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "BidAmount", "DateOfBid", "Username" },
                values: new object[] { 200.0, new DateTime(2023, 10, 22, 23, 21, 11, 995, DateTimeKind.Local).AddTicks(3434), "popcorn@gmail.com" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "BidAmount", "DateOfBid", "Username" },
                values: new object[] { 140.0, new DateTime(2023, 10, 22, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3431), "emil@hotmale.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "Description", "EndDate", "Name", "Username" },
                values: new object[] { new DateTime(2023, 10, 22, 12, 18, 57, 944, DateTimeKind.Local).AddTicks(5765), "Min andra auktion", new DateTime(2023, 10, 22, 12, 8, 57, 944, DateTimeKind.Local).AddTicks(5767), "Auction2", "agge@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "Description", "EndDate", "Name", "StartingPrice" },
                values: new object[] { new DateTime(2023, 10, 22, 12, 18, 57, 944, DateTimeKind.Local).AddTicks(5675), "Min första auktion", new DateTime(2024, 10, 22, 12, 18, 57, 944, DateTimeKind.Local).AddTicks(5704), "Auction1", 0 });

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
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 22, 11, 38, 57, 944, DateTimeKind.Local).AddTicks(5770), "Emil" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "BidAmount", "DateOfBid", "Username" },
                values: new object[] { 58.0, new DateTime(2023, 10, 22, 12, 38, 57, 944, DateTimeKind.Local).AddTicks(5710), "Albin" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "BidAmount", "DateOfBid", "Username" },
                values: new object[] { 50.0, new DateTime(2023, 10, 22, 12, 28, 57, 944, DateTimeKind.Local).AddTicks(5708), "Emil" });
        }
    }
}
