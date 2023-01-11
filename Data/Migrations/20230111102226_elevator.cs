using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomenProekt.Data.Migrations
{
    public partial class elevator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Elevator",
                table: "EstateExtras",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elevator",
                table: "EstateExtras");
        }
    }
}
