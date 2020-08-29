using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class UpdateBasicAndPassiveSkillRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_skill_card_card_id",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "ix_skill_card_id",
                table: "skill");

            migrationBuilder.DropIndex(
                name: "ix_card_passive_skill_id",
                table: "card");

            migrationBuilder.DropColumn(
                name: "card_id",
                table: "skill");

            migrationBuilder.CreateTable(
                name: "card_basic_skill",
                columns: table => new
                {
                    card_id = table.Column<int>(nullable: false),
                    basic_skill_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card_basic_skill", x => new { x.card_id, x.basic_skill_id });
                    table.ForeignKey(
                        name: "fk_card_basic_skill_skill_basic_skill_id",
                        column: x => x.basic_skill_id,
                        principalTable: "skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_card_basic_skill_card_card_id",
                        column: x => x.card_id,
                        principalTable: "card",
                        principalColumn: "card_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_card_passive_skill_id",
                table: "card",
                column: "passive_skill_id");

            migrationBuilder.CreateIndex(
                name: "ix_card_basic_skill_basic_skill_id",
                table: "card_basic_skill",
                column: "basic_skill_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card_basic_skill");

            migrationBuilder.DropIndex(
                name: "ix_card_passive_skill_id",
                table: "card");

            migrationBuilder.AddColumn<int>(
                name: "card_id",
                table: "skill",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_skill_card_id",
                table: "skill",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "ix_card_passive_skill_id",
                table: "card",
                column: "passive_skill_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_skill_card_card_id",
                table: "skill",
                column: "card_id",
                principalTable: "card",
                principalColumn: "card_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
