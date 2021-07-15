using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class change_table_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_CarOwner_Id_Owner",
                table: "CarDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_CarServices_Id_Services",
                table: "CarDetails");

            migrationBuilder.DropIndex(
                name: "IX_CarDetails_Id_Owner",
                table: "CarDetails");

            migrationBuilder.DropIndex(
                name: "IX_CarDetails_Id_Services",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Id_Owner",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "Id_Services",
                table: "CarDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id_CarDetails",
                table: "CarServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_CarOwner",
                table: "CarServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CarDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_Id_CarDetails",
                table: "CarServices",
                column: "Id_CarDetails");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_Id_CarOwner",
                table: "CarServices",
                column: "Id_CarOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_CarDetails_Id_CarDetails",
                table: "CarServices",
                column: "Id_CarDetails",
                principalTable: "CarDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_CarOwner_Id_CarOwner",
                table: "CarServices",
                column: "Id_CarOwner",
                principalTable: "CarOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_CarDetails_Id_CarDetails",
                table: "CarServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_CarOwner_Id_CarOwner",
                table: "CarServices");

            migrationBuilder.DropIndex(
                name: "IX_CarServices_Id_CarDetails",
                table: "CarServices");

            migrationBuilder.DropIndex(
                name: "IX_CarServices_Id_CarOwner",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "Id_CarDetails",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "Id_CarOwner",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CarDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id_Owner",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Services",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_Id_Owner",
                table: "CarDetails",
                column: "Id_Owner");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_Id_Services",
                table: "CarDetails",
                column: "Id_Services");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_CarOwner_Id_Owner",
                table: "CarDetails",
                column: "Id_Owner",
                principalTable: "CarOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_CarServices_Id_Services",
                table: "CarDetails",
                column: "Id_Services",
                principalTable: "CarServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
