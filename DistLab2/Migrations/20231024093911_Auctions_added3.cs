using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class Auctions_added3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 39, 11, 149, DateTimeKind.Local).AddTicks(400), new DateTime(2023, 10, 24, 11, 29, 11, 149, DateTimeKind.Local).AddTicks(403) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 39, 11, 149, DateTimeKind.Local).AddTicks(356), new DateTime(2023, 10, 24, 11, 29, 11, 149, DateTimeKind.Local).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 4, 11, 39, 11, 149, DateTimeKind.Local).AddTicks(187), new DateTime(2023, 10, 23, 11, 39, 11, 149, DateTimeKind.Local).AddTicks(229) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 24, 11, 19, 11, 149, DateTimeKind.Local).AddTicks(410), "agge@hotmail.se" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -5,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 10, 59, 11, 149, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 11, 19, 11, 149, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 10, 59, 11, 149, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 23, 39, 11, 149, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 11, 39, 11, 149, DateTimeKind.Local).AddTicks(234));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 27, 7, 264, DateTimeKind.Local).AddTicks(6903), new DateTime(2023, 10, 24, 11, 17, 7, 264, DateTimeKind.Local).AddTicks(6906) });

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

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 24, 11, 7, 7, 264, DateTimeKind.Local).AddTicks(6913), "algot@hotmail.se" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -5,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 10, 47, 7, 264, DateTimeKind.Local).AddTicks(6910));

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
        }
    }
}
