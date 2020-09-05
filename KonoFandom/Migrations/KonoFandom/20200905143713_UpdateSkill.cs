using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class UpdateSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_skill_effect_buff_effect_id",
                table: "skill");

            migrationBuilder.DropForeignKey(
                name: "fk_skill_effect_debuff_effect_id",
                table: "skill");

            migrationBuilder.AlterColumn<int>(
                name: "debuff_effect_id",
                table: "skill",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "buff_effect_id",
                table: "skill",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_skill_effect_buff_effect_id",
                table: "skill",
                column: "buff_effect_id",
                principalTable: "effect",
                principalColumn: "effect_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_skill_effect_debuff_effect_id",
                table: "skill",
                column: "debuff_effect_id",
                principalTable: "effect",
                principalColumn: "effect_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_skill_effect_buff_effect_id",
                table: "skill");

            migrationBuilder.DropForeignKey(
                name: "fk_skill_effect_debuff_effect_id",
                table: "skill");

            migrationBuilder.AlterColumn<int>(
                name: "debuff_effect_id",
                table: "skill",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "buff_effect_id",
                table: "skill",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_skill_effect_buff_effect_id",
                table: "skill",
                column: "buff_effect_id",
                principalTable: "effect",
                principalColumn: "effect_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_skill_effect_debuff_effect_id",
                table: "skill",
                column: "debuff_effect_id",
                principalTable: "effect",
                principalColumn: "effect_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
