﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Course_Entity;

namespace Student_Course_Entity.Migrations
{
    [DbContext(typeof(HumberContext))]
    [Migration("20200202224940_Create DB")]
    partial class CreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Student_Course_Entity.CoursePoco", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .HasColumnName("Course Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseToTeacherTeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseId");

                    b.HasIndex("CourseToTeacherTeacherId");

                    b.ToTable("Course Details");
                });

            modelBuilder.Entity("Student_Course_Entity.GradePoco", b =>
                {
                    b.Property<Guid>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Course")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GradeToCourseCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GradeToStudentStudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("MaxScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Student")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SubScore")
                        .HasColumnName("Individual Score")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GradeId");

                    b.HasIndex("GradeToCourseCourseId");

                    b.HasIndex("GradeToStudentStudentId");

                    b.ToTable("Student Grades");
                });

            modelBuilder.Entity("Student_Course_Entity.StudentPoco", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnName("Student Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentToCourseCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentToCourseCourseId");

                    b.ToTable("Student Details");
                });

            modelBuilder.Entity("Student_Course_Entity.TeacherPoco", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Teacher Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeacherName")
                        .HasColumnName("Teacher Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers Details");
                });

            modelBuilder.Entity("Student_Course_Entity.CoursePoco", b =>
                {
                    b.HasOne("Student_Course_Entity.TeacherPoco", "CourseToTeacher")
                        .WithMany("TeacherToCourse")
                        .HasForeignKey("CourseToTeacherTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Student_Course_Entity.GradePoco", b =>
                {
                    b.HasOne("Student_Course_Entity.CoursePoco", "GradeToCourse")
                        .WithMany("CourseToGrade")
                        .HasForeignKey("GradeToCourseCourseId");

                    b.HasOne("Student_Course_Entity.StudentPoco", "GradeToStudent")
                        .WithMany("StudentToGrade")
                        .HasForeignKey("GradeToStudentStudentId");
                });

            modelBuilder.Entity("Student_Course_Entity.StudentPoco", b =>
                {
                    b.HasOne("Student_Course_Entity.CoursePoco", "StudentToCourse")
                        .WithMany("CourseToStudent")
                        .HasForeignKey("StudentToCourseCourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
