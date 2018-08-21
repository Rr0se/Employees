using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApiToProject.Migrations
{
    public partial class languageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingLevel",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "SpeakingLevel",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "WritingLevel",
                table: "Languages");

            migrationBuilder.AddColumn<int>(
                name: "ReadingLevel",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakingLevel",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WritingLevel",
                table: "EmployeeLanguages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadingLevel",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "SpeakingLevel",
                table: "EmployeeLanguages");

            migrationBuilder.DropColumn(
                name: "WritingLevel",
                table: "EmployeeLanguages");

            migrationBuilder.AddColumn<int>(
                name: "ReadingLevel",
                table: "Languages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeakingLevel",
                table: "Languages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WritingLevel",
                table: "Languages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
