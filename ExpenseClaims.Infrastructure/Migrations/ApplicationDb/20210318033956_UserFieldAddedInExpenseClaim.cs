using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseClaims.Infrastructure.Migrations.ApplicationDb
{
    public partial class UserFieldAddedInExpenseClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequesterId",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "RequesterId",
                table: "Claims");
        }
    }
}
