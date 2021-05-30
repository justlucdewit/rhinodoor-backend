using Microsoft.EntityFrameworkCore.Migrations;

namespace Rhinodoor_backend.Migrations
{
    public partial class Colortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "DoorOptions");

            migrationBuilder.DropColumn(
                name: "ColorRAL",
                table: "DoorOptions");

            migrationBuilder.CreateTable(
                name: "DoorColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoorId = table.Column<int>(type: "int", nullable: false),
                    ColorRAL = table.Column<int>(type: "int", nullable: false),
                    ColorHEX = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoorColors_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoorColors_DoorId",
                table: "DoorColors",
                column: "DoorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoorColors");

            migrationBuilder.AddColumn<int>(
                name: "ColorHex",
                table: "DoorOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorRAL",
                table: "DoorOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
