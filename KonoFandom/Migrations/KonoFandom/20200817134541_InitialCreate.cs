using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    weapon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_character", x => x.character_id);
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
                    character_id = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "ix_card_character_id",
                table: "card",
                column: "character_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "character");
        }
    }
}
