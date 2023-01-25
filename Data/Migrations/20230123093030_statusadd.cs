using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomenProekt.Data.Migrations
{
    public partial class statusadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstateStatus",
                table: "Estates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstateStatus",
                table: "Estates");
        }
    }
}
