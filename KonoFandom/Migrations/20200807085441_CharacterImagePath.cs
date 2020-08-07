using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations
{
    public partial class CharacterImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "character_image_path",
                table: "character",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "character_image_path",
                table: "character");
        }
    }
}
