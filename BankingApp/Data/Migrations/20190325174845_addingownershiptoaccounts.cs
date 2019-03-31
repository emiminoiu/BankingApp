using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.Data.Migrations
{
    public partial class addingownershiptoaccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerFirstName",
                table: "accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerLastName",
                table: "accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerFirstName",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "OwnerLastName",
                table: "accounts");
        }
    }
}
