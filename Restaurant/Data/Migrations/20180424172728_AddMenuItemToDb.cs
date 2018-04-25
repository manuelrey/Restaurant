using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Restaurant.Data.Migrations
{
    public partial class AddMenuItemToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes");

            migrationBuilder.RenameTable(
                name: "FoodTypes",
                newName: "FoodType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodType",
                table: "FoodType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    FoodTypeId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Spicyness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_CategoryType_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItem_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoryId",
                table: "MenuItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_FoodTypeId",
                table: "MenuItem",
                column: "FoodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodType",
                table: "FoodType");

            migrationBuilder.RenameTable(
                name: "FoodType",
                newName: "FoodTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes",
                column: "Id");
        }
    }
}
