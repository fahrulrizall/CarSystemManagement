using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class delete_detail_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_CarDetails_Id_CarDetails",
                table: "CarServices");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropIndex(
                name: "IX_CarServices_Id_CarDetails",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "Id_CarDetails",
                table: "CarServices");

            migrationBuilder.AddColumn<DateTime>(
                name: "Brought",
                table: "CarServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brought",
                table: "CarServices");

            migrationBuilder.AddColumn<int>(
                name: "Id_CarDetails",
                table: "CarServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brought = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_Id_CarDetails",
                table: "CarServices",
                column: "Id_CarDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_CarDetails_Id_CarDetails",
                table: "CarServices",
                column: "Id_CarDetails",
                principalTable: "CarDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
