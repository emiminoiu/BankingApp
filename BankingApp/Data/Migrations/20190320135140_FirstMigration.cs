using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Name = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    State = table.Column<string>(maxLength: 20, nullable: true),
                    Zip_Code = table.Column<string>(maxLength: 20, nullable: true),
                    Phone_Number = table.Column<string>(maxLength: 20, nullable: true),
                    Street_Address = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    Street_Address = table.Column<string>(maxLength: 30, nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    State = table.Column<string>(maxLength: 20, nullable: true),
                    Sex = table.Column<string>(maxLength: 1, nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account_Balance = table.Column<decimal>(nullable: false),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    Account_Type = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "creditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Maximum_Limit = table.Column<decimal>(nullable: false),
                    Expire_Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_creditCards_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration_in_Months = table.Column<int>(nullable: false),
                    Loan_Start_Date = table.Column<DateTime>(nullable: false),
                    AmountTaken = table.Column<decimal>(nullable: false),
                    AmountRepaid = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loans_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    type = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Transaction_Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cc_Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    Transaction_Date = table.Column<DateTime>(nullable: false),
                    MerchantDetails = table.Column<string>(nullable: true),
                    CreditCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cc_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cc_Transactions_creditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "creditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_BranchId",
                table: "accounts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_CustomerId",
                table: "accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_cc_Transactions_CreditCardId",
                table: "cc_Transactions",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_creditCards_CustomerId",
                table: "creditCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_BranchId",
                table: "employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_CustomerId",
                table: "loans",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_CustomerId",
                table: "transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "cc_Transactions");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "creditCards");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
