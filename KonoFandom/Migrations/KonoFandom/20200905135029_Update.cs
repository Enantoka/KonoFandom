using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cooldown",
                table: "skill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "agility",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "dark_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "dexterity",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "earth_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "fire_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "health_points",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "light_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "lightning_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "luck",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "magic_attack",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "magic_defense",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "physical_attack",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "physical_defense",
                table: "card",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "water_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "wind_resistance",
                table: "card",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cooldown",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "agility",
                table: "card");

            migrationBuilder.DropColumn(
                name: "dark_resistance",
                table: "card");

            migrationBuilder.DropColumn(
                name: "dexterity",
                table: "card");

            migrationBuilder.DropColumn(
                name: "earth_resistance",
                table: "card");

            migrationBuilder.DropColumn(
                name: "fire_resistance",
                table: "card");

            migrationBuilder.DropColumn(
                name: "health_points",
                table: "card");

            migrationBuilder.DropColumn(
                name: "light_resistance",
                table: "card");

            migrationBuilder.DropColumn(
                name: "lightning_resistance",
                table: "card");

            migrationBuilder.DropColumn(
                name: "luck",
                table: "card");

            migrationBuilder.DropColumn(
                name: "magic_attack",
                table: "card");

            migrationBuilder.DropColumn(
                name: "magic_defense",
                table: "card");

            migrationBuilder.DropColumn(
                name: "physical_attack",
                table: "card");

            migrationBuilder.DropColumn(
                name: "physical_defense",
                table: "card");

            migrationBuilder.DropColumn(
                name: "water_resistance",
                table: "card");

            migrationBuilder.DropColumn(
                name: "wind_resistance",
                table: "card");
        }
    }
}
