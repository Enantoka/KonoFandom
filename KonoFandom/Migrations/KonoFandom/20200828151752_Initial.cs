using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    skill_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    image_path = table.Column<string>(nullable: true),
                    discriminator = table.Column<string>(nullable: false),
                    card_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_skill", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    character_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 20, nullable: true),
                    biography = table.Column<string>(nullable: true),
                    icon_image_path = table.Column<string>(nullable: true),
                    character_image_path = table.Column<string>(nullable: true),
                    weapon = table.Column<int>(nullable: false),
                    ultimate_skill_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_character", x => x.character_id);
                    table.ForeignKey(
                        name: "fk_character_skill_ultimate_skill_id",
                        column: x => x.ultimate_skill_id,
                        principalTable: "skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    card_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    rarity = table.Column<int>(nullable: false),
                    image_path = table.Column<string>(nullable: true),
                    character_id = table.Column<int>(nullable: false),
                    passive_skill_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card", x => x.card_id);
                    table.ForeignKey(
                        name: "fk_card_character_character_id",
                        column: x => x.character_id,
                        principalTable: "character",
                        principalColumn: "character_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_card_skill_passive_skill_id",
                        column: x => x.passive_skill_id,
                        principalTable: "skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_card_character_id",
                table: "card",
                column: "character_id");

            migrationBuilder.CreateIndex(
                name: "ix_card_passive_skill_id",
                table: "card",
                column: "passive_skill_id");

            migrationBuilder.CreateIndex(
                name: "ix_character_ultimate_skill_id",
                table: "character",
                column: "ultimate_skill_id");

            migrationBuilder.CreateIndex(
                name: "ix_skill_card_id",
                table: "skill",
                column: "card_id");

            migrationBuilder.AddForeignKey(
                name: "fk_skill_card_card_id",
                table: "skill",
                column: "card_id",
                principalTable: "card",
                principalColumn: "card_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_character_character_id",
                table: "card");

            migrationBuilder.DropForeignKey(
                name: "fk_card_skill_passive_skill_id",
                table: "card");

            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "card");
        }
    }
}
