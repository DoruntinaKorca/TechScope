using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemovedPropertiesFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userLastName",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userFirstName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userLastName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
