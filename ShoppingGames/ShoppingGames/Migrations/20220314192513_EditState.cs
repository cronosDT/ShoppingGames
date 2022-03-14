using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingGames.Migrations
{
    public partial class EditState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_categories_CategoryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CategoryId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "States");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CategoryId",
                table: "States",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_categories_CategoryId",
                table: "States",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
