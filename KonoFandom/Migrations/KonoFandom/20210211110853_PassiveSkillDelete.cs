using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class PassiveSkillDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card");

            migrationBuilder.AddForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card",
                column: "passive_skill_id",
                principalTable: "skill",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card");

            migrationBuilder.AddForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card",
                column: "passive_skill_id",
                principalTable: "skill",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
