using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PMProjet.Migrations
{
    public partial class AddThumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Education",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Education");
        }
    }
}
