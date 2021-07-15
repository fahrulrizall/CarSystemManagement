using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class add_email_to_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CarOwner",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CarOwner");
        }
    }
}
