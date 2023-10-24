using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class Auctions_added4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 41, 12, 473, DateTimeKind.Local).AddTicks(1758), new DateTime(2023, 10, 24, 11, 31, 12, 473, DateTimeKind.Local).AddTicks(1761) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 14, 11, 41, 12, 473, DateTimeKind.Local).AddTicks(1714), new DateTime(2023, 10, 24, 11, 31, 12, 473, DateTimeKind.Local).AddTicks(1718) });

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDate", "EndDate" },
                values: new object[] { new DateTime(2023, 10, 4, 11, 41, 12, 473, DateTimeKind.Local).AddTicks(1547), new DateTime(2023, 10, 23, 11, 41, 12, 473, DateTimeKind.Local).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "DateOfBid", "Username" },
                values: new object[] { new DateTime(2023, 10, 24, 11, 21, 12, 473, DateTimeKind.Local).AddTicks(1768), "agge@hotmail.com" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -5,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 11, 1, 12, 473, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -4,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 11, 21, 12, 473, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 24, 11, 1, 12, 473, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 23, 41, 12, 473, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "DateOfBid",
                value: new DateTime(2023, 10, 22, 11, 41, 12, 473, DateTimeKind.Local).AddTicks(1595));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
