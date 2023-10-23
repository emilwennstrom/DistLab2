using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistLab2.Migrations
{
    /// <inheritdoc />
    public partial class Intital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BidAmount = table.Column<double>(type: "float", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDbs_AuctionDbs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidDbs_AuctionId",
                table: "BidDbs",
                column: "AuctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDbs");

            migrationBuilder.DropTable(
                name: "AuctionDbs");
        }
    }
}
