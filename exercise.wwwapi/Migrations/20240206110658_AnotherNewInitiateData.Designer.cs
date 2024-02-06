﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using exercise.wwwapi.Data;

#nullable disable

namespace exercise.wwwapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240206110658_AnotherNewInitiateData")]
    partial class AnotherNewInitiateData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("exercise.wwwapi.DataModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StartDate = new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9111),
                            Title = "Math"
                        },
                        new
                        {
                            Id = 2,
                            StartDate = new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9198),
                            Title = "Literature"
                        },
                        new
                        {
                            Id = 3,
                            StartDate = new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9221),
                            Title = "Arts"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AverageGrade")
                        .HasColumnType("real")
                        .HasColumnName("average_grade");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dob");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AverageGrade = 3f,
                            CourseId = 1,
                            DOB = new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9316),
                            FirstName = "Sandra",
                            LastName = "Collins"
                        },
                        new
                        {
                            Id = 2,
                            AverageGrade = 4f,
                            CourseId = 3,
                            DOB = new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9337),
                            FirstName = "Mike",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            AverageGrade = 5f,
                            CourseId = 2,
                            DOB = new DateTime(2024, 2, 6, 11, 6, 57, 517, DateTimeKind.Utc).AddTicks(9343),
                            FirstName = "Heather",
                            LastName = "Dunst"
                        });
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Student", b =>
                {
                    b.HasOne("exercise.wwwapi.DataModels.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("exercise.wwwapi.DataModels.Course", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
