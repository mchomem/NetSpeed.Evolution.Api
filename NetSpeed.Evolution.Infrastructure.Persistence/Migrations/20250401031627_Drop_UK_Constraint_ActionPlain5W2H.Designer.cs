﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetSpeed.Evolution.Infrastructure.Persistence.Contexts;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250401031627_Drop_UK_Constraint_ActionPlain5W2H")]
    partial class Drop_UK_Constraint_ActionPlain5W2H
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.ActionPlain5W2H", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<long>("CycleId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("How")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("HowMuch")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImprovementPoint")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("What")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("When")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Where")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Who")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Why")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CycleId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ActionPlain5W2H", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Cycle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Year")
                        .IsUnique()
                        .HasDatabaseName("UK_Cycle_Year");

                    b.ToTable("Cycle", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UK_Department_Name");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<long>("JobTitleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ManagerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RegistrationNumber")
                        .IsUnique()
                        .HasDatabaseName("UK_Employee_RegistrationNumber");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.EmployeeHardSkill", b =>
                {
                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("HardSkillId")
                        .HasColumnType("bigint");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("EmployeeId", "HardSkillId");

                    b.HasIndex("HardSkillId");

                    b.ToTable("EmployeeHardSkills", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.HardSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UK_HardSkill_Name");

                    b.ToTable("HardSkill", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.JobTitle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UK_JobTitle_Name");

                    b.ToTable("JobTitle", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Opportunity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("SwotId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SwotId");

                    b.ToTable("Opportunity", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Strength", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("SwotId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SwotId");

                    b.ToTable("Strength", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Swot", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<long>("CycleId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CycleId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("Id", "CycleId")
                        .IsUnique()
                        .HasDatabaseName("UK_Swot_Id_CycleId");

                    b.ToTable("Swot", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Threat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("SwotId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SwotId");

                    b.ToTable("Threat", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Blocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("UK_User_Login");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Weakness", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<long>("SwotId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SwotId");

                    b.ToTable("Weakness", (string)null);
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.ActionPlain5W2H", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Cycle", "Cycle")
                        .WithMany("ActionPlains5W2H")
                        .HasForeignKey("CycleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ActionPlain5W2H_Cycle_CycleId");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Employee", "Employee")
                        .WithMany("ActionPlains5W2H")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ActionPlain5W2H_Employee_EmployeeId");

                    b.Navigation("Cycle");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Employee", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Employee_Department_DepartmentId");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("NetSpeed.Evolution.Core.Domain.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_User_Employee_Id");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.JobTitle", "JobTitle")
                        .WithMany("Employees")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Employee_JobTitle_JobTitleId");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Employee", "Manager")
                        .WithMany("Subordinates")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Employee_Employee_ManagerId");

                    b.Navigation("Department");

                    b.Navigation("JobTitle");

                    b.Navigation("Manager");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.EmployeeHardSkill", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeHardSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeHardSkills_Employee_EmployeeId");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.HardSkill", "HardSkill")
                        .WithMany("EmployeeHardSkills")
                        .HasForeignKey("HardSkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeHardSkills_HardSkill_HardSkillId");

                    b.Navigation("Employee");

                    b.Navigation("HardSkill");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Opportunity", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Swot", "Swot")
                        .WithMany("Opportunities")
                        .HasForeignKey("SwotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Opportunity_Swot_SwotId");

                    b.Navigation("Swot");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Strength", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Swot", "Swot")
                        .WithMany("Strengths")
                        .HasForeignKey("SwotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Strength_Swot_SwotId");

                    b.Navigation("Swot");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Swot", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.User", "CreatedBy")
                        .WithMany("SwotsCreatedByUser")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Swot_User_CreatedById");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Cycle", "Cycle")
                        .WithMany("Swots")
                        .HasForeignKey("CycleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Swot_Cycle_CycleId");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Employee", "Employee")
                        .WithMany("Swots")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Swot_Employee_EmployeeId");

                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.User", "UpdatedBy")
                        .WithMany("SwotsUpdatedByUser")
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Swot_User_UpdatedById");

                    b.Navigation("CreatedBy");

                    b.Navigation("Cycle");

                    b.Navigation("Employee");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Threat", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Swot", "Swot")
                        .WithMany("Threats")
                        .HasForeignKey("SwotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Threat_Swot_SwotId");

                    b.Navigation("Swot");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Weakness", b =>
                {
                    b.HasOne("NetSpeed.Evolution.Core.Domain.Entities.Swot", "Swot")
                        .WithMany("Weaknesses")
                        .HasForeignKey("SwotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Weakness_Swot_SwotId");

                    b.Navigation("Swot");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Cycle", b =>
                {
                    b.Navigation("ActionPlains5W2H");

                    b.Navigation("Swots");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Employee", b =>
                {
                    b.Navigation("ActionPlains5W2H");

                    b.Navigation("EmployeeHardSkills");

                    b.Navigation("Subordinates");

                    b.Navigation("Swots");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.HardSkill", b =>
                {
                    b.Navigation("EmployeeHardSkills");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.JobTitle", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.Swot", b =>
                {
                    b.Navigation("Opportunities");

                    b.Navigation("Strengths");

                    b.Navigation("Threats");

                    b.Navigation("Weaknesses");
                });

            modelBuilder.Entity("NetSpeed.Evolution.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("SwotsCreatedByUser");

                    b.Navigation("SwotsUpdatedByUser");
                });
#pragma warning restore 612, 618
        }
    }
}
