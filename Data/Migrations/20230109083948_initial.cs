using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomenProekt.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<int>(type: "int", nullable: false),
                    Neighbourhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstateType = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    MaxFloor = table.Column<int>(type: "int", nullable: false),
                    ExtrasId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estates_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstateExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasElectricity = table.Column<bool>(type: "bit", nullable: false),
                    HasWater = table.Column<bool>(type: "bit", nullable: false),
                    HasGas = table.Column<bool>(type: "bit", nullable: false),
                    East = table.Column<bool>(type: "bit", nullable: false),
                    West = table.Column<bool>(type: "bit", nullable: false),
                    South = table.Column<bool>(type: "bit", nullable: false),
                    North = table.Column<bool>(type: "bit", nullable: false),
                    EstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstateExtras_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateExtras_EstateId",
                table: "EstateExtras",
                column: "EstateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_AddressId",
                table: "Estates",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateExtras");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
