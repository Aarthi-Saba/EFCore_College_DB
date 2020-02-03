using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Course_Entity.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers Details",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(name: "Teacher Id", nullable: false),
                    TeacherName = table.Column<string>(name: "Teacher Name", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers Details", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Course Details",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    CourseName = table.Column<string>(name: "Course Name", nullable: true),
                    TeacherId = table.Column<Guid>(nullable: false),
                    CourseToTeacherTeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course Details", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course Details_Teachers Details_CourseToTeacherTeacherId",
                        column: x => x.CourseToTeacherTeacherId,
                        principalTable: "Teachers Details",
                        principalColumn: "Teacher Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student Details",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(nullable: false),
                    StudentName = table.Column<string>(name: "Student Name", nullable: true),
                    StudentToCourseCourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student Details", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student Details_Course Details_StudentToCourseCourseId",
                        column: x => x.StudentToCourseCourseId,
                        principalTable: "Course Details",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student Grades",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(nullable: false),
                    Student = table.Column<Guid>(nullable: false),
                    Course = table.Column<Guid>(nullable: false),
                    IndividualScore = table.Column<decimal>(name: "Individual Score", nullable: false),
                    MaxScore = table.Column<decimal>(nullable: false),
                    GradeToStudentStudentId = table.Column<Guid>(nullable: true),
                    GradeToCourseCourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Student Grades_Course Details_GradeToCourseCourseId",
                        column: x => x.GradeToCourseCourseId,
                        principalTable: "Course Details",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student Grades_Student Details_GradeToStudentStudentId",
                        column: x => x.GradeToStudentStudentId,
                        principalTable: "Student Details",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course Details_CourseToTeacherTeacherId",
                table: "Course Details",
                column: "CourseToTeacherTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Student Details_StudentToCourseCourseId",
                table: "Student Details",
                column: "StudentToCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student Grades_GradeToCourseCourseId",
                table: "Student Grades",
                column: "GradeToCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student Grades_GradeToStudentStudentId",
                table: "Student Grades",
                column: "GradeToStudentStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student Grades");

            migrationBuilder.DropTable(
                name: "Student Details");

            migrationBuilder.DropTable(
                name: "Course Details");

            migrationBuilder.DropTable(
                name: "Teachers Details");
        }
    }
}
