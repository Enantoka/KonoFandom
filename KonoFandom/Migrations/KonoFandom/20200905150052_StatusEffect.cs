using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class StatusEffect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skill_status_effect",
                columns: table => new
                {
                    skill_id = table.Column<int>(nullable: false),
                    status_effect_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_skill_status_effect", x => new { x.skill_id, x.status_effect_id });
                    table.ForeignKey(
                        name: "fk_skill_status_effect_skill_skill_id",
                        column: x => x.skill_id,
                        principalTable: "skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_skill_status_effect_effect_status_effect_id",
                        column: x => x.status_effect_id,
                        principalTable: "effect",
                        principalColumn: "effect_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_skill_status_effect_status_effect_id",
                table: "skill_status_effect",
                column: "status_effect_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "skill_status_effect");
        }
    }
}
