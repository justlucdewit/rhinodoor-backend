using Microsoft.EntityFrameworkCore.Migrations;

namespace Rhinodoor_backend.Migrations
{
    public partial class OrderDoorOptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoorColorId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DoorColorId",
                table: "Orders",
                column: "DoorColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DoorColors_DoorColorId",
                table: "Orders",
                column: "DoorColorId",
                principalTable: "DoorColors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DoorColors_DoorColorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DoorColorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DoorColorId",
                table: "Orders");
        }
    }
}
