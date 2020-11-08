using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class OptionalPassiveSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card");

            migrationBuilder.AlterColumn<int>(
                name: "passive_skill_id",
                table: "card",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card",
                column: "passive_skill_id",
                principalTable: "skill",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card");

            migrationBuilder.AlterColumn<int>(
                name: "passive_skill_id",
                table: "card",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card",
                column: "passive_skill_id",
                principalTable: "skill",
                principalColumn: "skill_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
