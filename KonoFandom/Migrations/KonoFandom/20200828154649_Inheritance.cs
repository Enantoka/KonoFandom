using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character");

            migrationBuilder.DropIndex(
                name: "ix_card_passive_skill_id",
                table: "card");

            migrationBuilder.CreateIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character",
                column: "ultimate_skill_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_card_passive_skill_id",
                table: "card",
                column: "passive_skill_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character");

            migrationBuilder.DropIndex(
                name: "ix_card_passive_skill_id",
                table: "card");

            migrationBuilder.CreateIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character",
                column: "ultimate_skill_id");

            migrationBuilder.CreateIndex(
                name: "ix_card_passive_skill_id",
                table: "card",
                column: "passive_skill_id");
        }
    }
}
