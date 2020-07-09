using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIDemo.Migrations
{
    public partial class AnotherPersonUpdateagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Persons");
        }
    }
}
