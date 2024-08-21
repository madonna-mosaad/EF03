﻿// <auto-generated />
using System;
using EF03.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF03.Migrations
{
    [DbContext(typeof(DepartmentDbContext))]
    partial class DepartmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF03.Entities.Course", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"), 10L, 10);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int?>("Top_Id")
                        .HasColumnType("int");

                    b.HasKey("CId");

                    b.HasIndex("Top_Id");

                    b.ToTable("Courses", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Course_Inst", b =>
                {
                    b.Property<int?>("Course_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int?>("Ins_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Evaluate")
                        .HasColumnType("int");

                    b.HasKey("Course_Id", "Ins_Id");

                    b.HasIndex("Ins_Id");

                    b.ToTable("Course_Inst", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Department", b =>
                {
                    b.Property<int>("DId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DId"), 10L, 10);

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int?>("ins_Id")
                        .HasColumnType("int");

                    b.HasKey("DId");

                    b.HasIndex("ins_Id");

                    b.ToTable("Departments", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"), 10L, 10);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Bouns")
                        .HasColumnType("float");

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int>("HourRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("InsId");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructors", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Stud_Course", b =>
                {
                    b.Property<int?>("Stud_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int?>("Course_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.HasKey("Stud_Id", "Course_Id");

                    b.HasIndex("Course_Id");

                    b.ToTable("Stud_Course", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Student", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SId"), 10L, 10);

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Cairo");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Dep_Id")
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SId");

                    b.HasIndex("Dep_Id");

                    b.ToTable("Students", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Topic", b =>
                {
                    b.Property<int>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TId"), 10L, 10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("TId");

                    b.ToTable("Topics", "dbo");
                });

            modelBuilder.Entity("EF03.Entities.Course", b =>
                {
                    b.HasOne("EF03.Entities.Topic", "Topic")
                        .WithMany("Courses")
                        .HasForeignKey("Top_Id");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("EF03.Entities.Course_Inst", b =>
                {
                    b.HasOne("EF03.Entities.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF03.Entities.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("Ins_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EF03.Entities.Department", b =>
                {
                    b.HasOne("EF03.Entities.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("ins_Id");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EF03.Entities.Instructor", b =>
                {
                    b.HasOne("EF03.Entities.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("Dept_Id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EF03.Entities.Stud_Course", b =>
                {
                    b.HasOne("EF03.Entities.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF03.Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("Stud_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EF03.Entities.Student", b =>
                {
                    b.HasOne("EF03.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Dep_Id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EF03.Entities.Course", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("EF03.Entities.Department", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("EF03.Entities.Instructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EF03.Entities.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EF03.Entities.Topic", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
