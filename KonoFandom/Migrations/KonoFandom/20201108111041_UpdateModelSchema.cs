using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations.KonoFandom
{
    public partial class UpdateModelSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cooldown",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "type",
                table: "element");

            migrationBuilder.DropColumn(
                name: "weapon",
                table: "character");

            migrationBuilder.AddColumn<int>(
                name: "charge_time",
                table: "skill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "element",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "character",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "character",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "character_voice",
                table: "character",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "weapon",
                table: "card",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "charge_time",
                table: "skill");

            migrationBuilder.DropColumn(
                name: "name",
                table: "element");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "character");

            migrationBuilder.DropColumn(
                name: "character_voice",
                table: "character");

            migrationBuilder.DropColumn(
                name: "weapon",
                table: "card");

            migrationBuilder.AddColumn<int>(
                name: "cooldown",
                table: "skill",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "element",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "character",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "weapon",
                table: "character",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
