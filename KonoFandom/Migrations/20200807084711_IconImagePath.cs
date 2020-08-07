﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KonoFandom.Migrations
{
    public partial class IconImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon_image_path",
                table: "character",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon_image_path",
                table: "character");
        }
    }
}
