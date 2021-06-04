using Microsoft.EntityFrameworkCore.Migrations;

namespace Rhinodoor_backend.Migrations
{
    public partial class FixDoorOptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DoorOptions_DoorOptionId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "DoorOptionId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DoorOptions_DoorOptionId",
                table: "Orders",
                column: "DoorOptionId",
                principalTable: "DoorOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DoorOptions_DoorOptionId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "DoorOptionId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DoorOptions_DoorOptionId",
                table: "Orders",
                column: "DoorOptionId",
                principalTable: "DoorOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
