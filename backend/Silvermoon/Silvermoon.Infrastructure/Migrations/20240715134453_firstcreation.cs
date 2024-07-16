using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Silvermoon.Infrastructure.Migrations
{
    public partial class firstcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "financial_transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    type = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_financial_transactions", x => x.transaction_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transfer_details",
                columns: table => new
                {
                    tranfer_details_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    from_account = table.Column<string>(type: "longtext", nullable: false),
                    to_account = table.Column<string>(type: "longtext", nullable: false),
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_details", x => x.tranfer_details_id);
                    table.ForeignKey(
                        name: "FK_transfer_details_financial_transactions_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "financial_transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    account_number = table.Column<string>(type: "longtext", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    card_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    card_number = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    expiration_date = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    security_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    cardtype = table.Column<int>(type: "int", nullable: false),
                    credit_limit = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    available_balance = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    issue_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusCard = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.card_id);
                    table.ForeignKey(
                        name: "FK_cards_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cards_account_id",
                table: "cards",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_details_transaction_id",
                table: "transfer_details",
                column: "transaction_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "transfer_details");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "financial_transactions");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
