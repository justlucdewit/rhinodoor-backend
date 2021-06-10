using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rhinodoor_backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoorImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoorOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoorId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoorOptions_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlacedBy = table.Column<int>(type: "int", nullable: false),
                    DoorId = table.Column<int>(type: "int", nullable: false),
                    DoorOptionId = table.Column<int>(type: "int", nullable: false),
                    DoorColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DoorColors_DoorColorId",
                        column: x => x.DoorColorId,
                        principalTable: "DoorColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DoorOptions_DoorOptionId",
                        column: x => x.DoorOptionId,
                        principalTable: "DoorOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_PlacedBy",
                        column: x => x.PlacedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoorColors_DoorId",
                table: "DoorColors",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoorOptions_DoorId",
                table: "DoorOptions",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DoorColorId",
                table: "Orders",
                column: "DoorColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DoorId",
                table: "Orders",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DoorOptionId",
                table: "Orders",
                column: "DoorOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PlacedBy",
                table: "Orders",
                column: "PlacedBy",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DoorColors");

            migrationBuilder.DropTable(
                name: "DoorOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doors");
        }
    }
}
