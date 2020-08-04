using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations
{
    public partial class NamingConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Character_CharacterID",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "character");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "card");

            migrationBuilder.RenameColumn(
                name: "Weapon",
                table: "character",
                newName: "weapon");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "character",
                newName: "biography");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "character",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "character",
                newName: "first_mid_name");

            migrationBuilder.RenameColumn(
                name: "CharacterID",
                table: "character",
                newName: "character_id");

            migrationBuilder.RenameColumn(
                name: "Rarity",
                table: "card",
                newName: "rarity");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "card",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "card",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "CharacterID",
                table: "card",
                newName: "character_id");

            migrationBuilder.RenameColumn(
                name: "CardID",
                table: "card",
                newName: "card_id");

            migrationBuilder.RenameIndex(
                name: "IX_Card_CharacterID",
                table: "card",
                newName: "ix_card_character_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_character",
                table: "character",
                column: "character_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_card",
                table: "card",
                column: "card_id");

            migrationBuilder.AddForeignKey(
                name: "fk_card_character_character_id",
                table: "card",
                column: "character_id",
                principalTable: "character",
                principalColumn: "character_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_card_character_character_id",
                table: "card");

            migrationBuilder.DropPrimaryKey(
                name: "pk_character",
                table: "character");

            migrationBuilder.DropPrimaryKey(
                name: "pk_card",
                table: "card");

            migrationBuilder.RenameTable(
                name: "character",
                newName: "Character");

            migrationBuilder.RenameTable(
                name: "card",
                newName: "Card");

            migrationBuilder.RenameColumn(
                name: "weapon",
                table: "Character",
                newName: "Weapon");

            migrationBuilder.RenameColumn(
                name: "biography",
                table: "Character",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Character",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_mid_name",
                table: "Character",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "Character",
                newName: "CharacterID");

            migrationBuilder.RenameColumn(
                name: "rarity",
                table: "Card",
                newName: "Rarity");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Card",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "Card",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "character_id",
                table: "Card",
                newName: "CharacterID");

            migrationBuilder.RenameColumn(
                name: "card_id",
                table: "Card",
                newName: "CardID");

            migrationBuilder.RenameIndex(
                name: "ix_card_character_id",
                table: "Card",
                newName: "IX_Card_CharacterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "CharacterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "CardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Character_CharacterID",
                table: "Card",
                column: "CharacterID",
                principalTable: "Character",
                principalColumn: "CharacterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
