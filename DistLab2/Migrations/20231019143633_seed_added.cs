using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class seed_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "CreationDate", "Description", "EndDate", "Name", "StartingPrice", "Username" },
                values: new object[] { -1, new DateTime(2023, 10, 19, 16, 36, 33, 681, DateTimeKind.Local).AddTicks(7545), "Min första auktion", new DateTime(2024, 10, 19, 16, 36, 33, 681, DateTimeKind.Local).AddTicks(7579), "Auction1", 0, "Algot" });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "DateOfBid", "Username" },
                values: new object[,]
                {
                    { -2, -1, 58.0, new DateTime(2023, 10, 19, 16, 56, 33, 681, DateTimeKind.Local).AddTicks(7711), "Albin" },
                    { -1, -1, 50.0, new DateTime(2023, 10, 19, 16, 46, 33, 681, DateTimeKind.Local).AddTicks(7708), "Emil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
