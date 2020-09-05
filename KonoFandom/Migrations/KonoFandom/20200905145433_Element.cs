using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class Element : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "element",
                columns: table => new
                {
                    element_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true),
                    image_path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_element", x => x.element_id);
                });

            migrationBuilder.CreateTable(
                name: "card_element",
                columns: table => new
                {
                    card_id = table.Column<int>(nullable: false),
                    element_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card_element", x => new { x.card_id, x.element_id });
                    table.ForeignKey(
                        name: "fk_card_element_card_card_id",
                        column: x => x.card_id,
                        principalTable: "card",
                        principalColumn: "card_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_card_element_element_element_id",
                        column: x => x.element_id,
                        principalTable: "element",
                        principalColumn: "element_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_card_element_element_id",
                table: "card_element",
                column: "element_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card_element");

            migrationBuilder.DropTable(
                name: "element");
        }
    }
}
