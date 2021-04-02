using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasySecuritiesManager.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderId = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tAccounts_tUsers_AccountHolderId",
                        column: x => x.AccountHolderId,
                        principalTable: "tUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tAssetTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheAccountId = table.Column<int>(type: "int", nullable: true),
                    IsPurchase = table.Column<bool>(type: "bit", nullable: false),
                    TheAsset_Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheAsset_PricePerShare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TheAsset_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheAsset_DayLow = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TheAsset_DayHigh = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TheAsset_YearHigh = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TheAsset_YearLow = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TheAsset_MarketCap = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TheAsset_TimeOfFetch = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Shares = table.Column<int>(type: "int", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAssetTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tAssetTransactions_tAccounts_TheAccountId",
                        column: x => x.TheAccountId,
                        principalTable: "tAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tAccounts_AccountHolderId",
                table: "tAccounts",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_tAssetTransactions_TheAccountId",
                table: "tAssetTransactions",
                column: "TheAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tAssetTransactions");

            migrationBuilder.DropTable(
                name: "tAccounts");

            migrationBuilder.DropTable(
                name: "tUsers");
        }
    }
}
