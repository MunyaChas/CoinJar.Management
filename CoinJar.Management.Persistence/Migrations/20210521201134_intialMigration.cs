using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinJar.Management.Persistence.Migrations
{
    public partial class intialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoinJarAuditModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Activity = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CoinName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(4,2)", precision: 4, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinJarAuditModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Amount = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(4,2)", precision: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinJarAuditModels");

            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
