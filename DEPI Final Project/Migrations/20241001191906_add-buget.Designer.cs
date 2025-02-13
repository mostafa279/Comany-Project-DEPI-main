﻿// <auto-generated />
using System;
using DEPI_Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEPI_Final_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241001191906_add-buget")]
    partial class addbuget
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DEPI_Final_Project.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Dependent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOFDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.EmployeeProjects", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOFDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Department", b =>
                {
                    b.HasOne("DEPI_Final_Project.Models.Employee", "Manager")
                        .WithOne("DepartmentManager")
                        .HasForeignKey("DEPI_Final_Project.Models.Department", "ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Dependent", b =>
                {
                    b.HasOne("DEPI_Final_Project.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Employee", b =>
                {
                    b.HasOne("DEPI_Final_Project.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.EmployeeProjects", b =>
                {
                    b.HasOne("DEPI_Final_Project.Models.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEPI_Final_Project.Models.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Project", b =>
                {
                    b.HasOne("DEPI_Final_Project.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Employee", b =>
                {
                    b.Navigation("DepartmentManager")
                        .IsRequired();

                    b.Navigation("Dependents");

                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("DEPI_Final_Project.Models.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
