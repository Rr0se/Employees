﻿// <auto-generated />
using ApiToProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ApiToProject.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20180822105656_ProjectFix")]
    partial class ProjectFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiToProject.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("Rating");

                    b.Property<string>("Specialization")
                        .IsRequired();

                    b.Property<int>("YearsOfWork");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ApiToProject.Entities.EmployeeLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeId");

                    b.Property<Guid>("LanguageId");

                    b.Property<int>("ReadingLevel");

                    b.Property<int>("SpeakingLevel");

                    b.Property<int>("WritingLevel");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("EmployeeId", "LanguageId");

                    b.ToTable("EmployeeLanguages");
                });

            modelBuilder.Entity("ApiToProject.Entities.EmployeeProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeId");

                    b.Property<DateTime>("JoinDate");

                    b.Property<Guid>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId", "EmployeeId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("ApiToProject.Entities.EmployeeSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EmployeeId");

                    b.Property<double>("ExperienceInYears");

                    b.Property<int>("Profficiency");

                    b.Property<Guid>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("EmployeeId", "SkillId");

                    b.ToTable("EmployeeSkills");
                });

            modelBuilder.Entity("ApiToProject.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LanguageName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ApiToProject.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientSector")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Technologies")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ApiToProject.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SkillName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ApiToProject.Entities.EmployeeLanguage", b =>
                {
                    b.HasOne("ApiToProject.Entities.Employee", "Employee")
                        .WithMany("EmployeeLanguages")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiToProject.Entities.Language", "Language")
                        .WithMany("EmployeeLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiToProject.Entities.EmployeeProject", b =>
                {
                    b.HasOne("ApiToProject.Entities.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiToProject.Entities.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiToProject.Entities.EmployeeSkill", b =>
                {
                    b.HasOne("ApiToProject.Entities.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiToProject.Entities.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}