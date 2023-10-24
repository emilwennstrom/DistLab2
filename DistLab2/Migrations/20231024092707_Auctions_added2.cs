using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class Auctions_added2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 27, 7, 264, DateTimeKind.Local).AddTicks(6859), new DateTime(2023, 10, 24, 11, 17, 7, 264, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 4, 11, 27, 7, 264, DateTimeKind.Local).AddTicks(6672), new DateTime(2023, 10, 23, 11, 27, 7, 264, DateTimeKind.Local).AddTicks(6722) });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "CreationDate", "Description", "EndDate", "Name", "StartingPrice", "Username" },
                values: new object[] { -3, new DateTime(2023, 10, 14, 11, 27, 7, 264, DateTimeKind.Local).AddTicks(6903), "lite jord medkommer", new DateTime(2023, 10, 24, 11, 17, 7, 264, DateTimeKind.Local).AddTicks(6906), "En kruka", 100, "emil@hotmale.com" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 11, 7, 7, 264, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 10, 47, 7, 264, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 23, 27, 7, 264, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 11, 27, 7, 264, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "AuctionId", "BidAmount", "DateOfBid", "Username" },
                values: new object[,]
                {
                    { -6, -2, 5800.0, new DateTime(2023, 10, 24, 11, 7, 7, 264, DateTimeKind.Local).AddTicks(6913), "algot@hotmail.se" },
                    { -5, -2, 501.0, new DateTime(2023, 10, 24, 10, 47, 7, 264, DateTimeKind.Local).AddTicks(6910), "popcorn@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3525), new DateTime(2023, 10, 24, 11, 11, 11, 995, DateTimeKind.Local).AddTicks(3529) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 4, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3390), new DateTime(2023, 10, 23, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3425) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 11, 1, 11, 995, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 10, 41, 11, 995, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 23, 21, 11, 995, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 11, 21, 11, 995, DateTimeKind.Local).AddTicks(3431));
        }
    }
}
