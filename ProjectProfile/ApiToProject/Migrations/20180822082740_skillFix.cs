using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApiToProject.Migrations
{
    public partial class skillFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperienceInYears",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Profficiency",
                table: "Skills");

            migrationBuilder.AddColumn<double>(
                name: "ExperienceInYears",
                table: "EmployeeSkills",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Profficiency",
                table: "EmployeeSkills",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperienceInYears",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "Profficiency",
                table: "EmployeeSkills");

            migrationBuilder.AddColumn<double>(
                name: "ExperienceInYears",
                table: "Skills",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Profficiency",
                table: "Skills",
                nullable: false,
                defaultValue: 0);
        }
    }
}
