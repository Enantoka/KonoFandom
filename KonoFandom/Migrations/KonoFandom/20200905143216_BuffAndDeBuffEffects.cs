using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class BuffAndDeBuffEffects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "buff_effect_id",
                table: "skill",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "debuff_effect_id",
                table: "skill",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "effect",
                columns: table => new
                {
                    effect_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    image_path = table.Column<string>(nullable: true),
                    discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_effect", x => x.effect_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_skill_buff_effect_id",
                table: "skill",
                column: "buff_effect_id");

            migrationBuilder.CreateIndex(
                name: "ix_skill_debuff_effect_id",
                table: "skill",
                column: "debuff_effect_id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_skill_effect_buff_effect_id",
                table: "skill");

            migrationBuilder.DropForeignKey(
                name: "fk_skill_effect_debuff_effect_id",
                table: "skill");

            migrationBuilder.DropTable(
                name: "effect");

            migrationBuilder.DropIndex(
                name: "ix_skill_buff_effect_id",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "ix_skill_debuff_effect_id",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "buff_effect_id",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "debuff_effect_id",
                table: "skill");
        }
    }
}
