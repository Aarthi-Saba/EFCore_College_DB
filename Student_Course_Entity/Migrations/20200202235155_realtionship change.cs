using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Course_Entity.Migrations
{
    public partial class realtionshipchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course Details_Teachers Details_CourseToTeacherTeacherId",
                table: "Course Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Student Grades_Course Details_GradeToCourseCourseId",
                table: "Student Grades");

            migrationBuilder.DropIndex(
                name: "IX_Student Grades_GradeToCourseCourseId",
                table: "Student Grades");

            migrationBuilder.DropIndex(
                name: "IX_Course Details_CourseToTeacherTeacherId",
                table: "Course Details");

            migrationBuilder.DropColumn(
                name: "GradeToCourseCourseId",
                table: "Student Grades");

            migrationBuilder.DropColumn(
                name: "CourseToTeacherTeacherId",
                table: "Course Details");

            migrationBuilder.AddColumn<Guid>(
                name: "Course",
                table: "Teachers Details",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Student Grades_Course",
                table: "Student Grades",
                column: "Course",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course Details_TeacherId",
                table: "Course Details",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course Details_Teachers Details_TeacherId",
                table: "Course Details",
                column: "TeacherId",
                principalTable: "Teachers Details",
                principalColumn: "Teacher Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student Grades_Course Details_Course",
                table: "Student Grades",
                column: "Course",
                principalTable: "Course Details",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course Details_Teachers Details_TeacherId",
                table: "Course Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Student Grades_Course Details_Course",
                table: "Student Grades");

            migrationBuilder.DropIndex(
                name: "IX_Student Grades_Course",
                table: "Student Grades");

            migrationBuilder.DropIndex(
                name: "IX_Course Details_TeacherId",
                table: "Course Details");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "Teachers Details");

            migrationBuilder.AddColumn<Guid>(
                name: "GradeToCourseCourseId",
                table: "Student Grades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseToTeacherTeacherId",
                table: "Course Details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Student Grades_GradeToCourseCourseId",
                table: "Student Grades",
                column: "GradeToCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course Details_CourseToTeacherTeacherId",
                table: "Course Details",
                column: "CourseToTeacherTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course Details_Teachers Details_CourseToTeacherTeacherId",
                table: "Course Details",
                column: "CourseToTeacherTeacherId",
                principalTable: "Teachers Details",
                principalColumn: "Teacher Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student Grades_Course Details_GradeToCourseCourseId",
                table: "Student Grades",
                column: "GradeToCourseCourseId",
                principalTable: "Course Details",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
