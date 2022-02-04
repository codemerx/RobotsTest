using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RobotsData.Migrations
{
    public partial class UpdateRobot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YLocation",
                table: "Robots",
                newName: "YPosition");

            migrationBuilder.RenameColumn(
                name: "XLocation",
                table: "Robots",
                newName: "XPosition");

            migrationBuilder.AddColumn<bool>(
                name: "IsLost",
                table: "Robots",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLost",
                table: "Robots");

            migrationBuilder.RenameColumn(
                name: "YPosition",
                table: "Robots",
                newName: "YLocation");

            migrationBuilder.RenameColumn(
                name: "XPosition",
                table: "Robots",
                newName: "XLocation");
        }
    }
}
