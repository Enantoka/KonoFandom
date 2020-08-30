using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class UpdateUltSkillRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_character_skill_ultimate_skill_id",
                table: "character");

            migrationBuilder.DropIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character");

            migrationBuilder.DropColumn(
                name: "ultimate_skill_id",
                table: "character");

            migrationBuilder.AddColumn<int>(
                name: "character_id",
                table: "skill",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_skill_character_id",
                table: "skill",
                column: "character_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_skill_character_character_id",
                table: "skill",
                column: "character_id",
                principalTable: "character",
                principalColumn: "character_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_skill_character_character_id",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "ix_skill_character_id",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "character_id",
                table: "skill");

            migrationBuilder.AddColumn<int>(
                name: "ultimate_skill_id",
                table: "character",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character",
                column: "ultimate_skill_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_character_skill_ultimate_skill_id",
                table: "character",
                column: "ultimate_skill_id",
                principalTable: "skill",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
