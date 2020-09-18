using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Account.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    AgencyNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    AccountHolder = table.Column<string>(type: "varchar(256)", nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Account",
                columns: new[] { "Id", "AccountBalance", "AccountHolder", "AccountNumber", "AgencyNumber" },
                values: new object[] { new Guid("ea48010f-9301-498d-a903-11a9d0edf110"), 10m, "João da Silva", "12345-x", "1234-0" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "CreateAt", "TransactionType", "Value" },
                values: new object[] { new Guid("327ac7f3-8f96-431e-8523-c83a6132bf2b"), new Guid("ea48010f-9301-498d-a903-11a9d0edf110"), new DateTime(2020, 9, 14, 19, 19, 42, 151, DateTimeKind.Local).AddTicks(5920), 2, 10m });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                schema: "dbo",
                table: "Transaction",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");
        }
    }
}
