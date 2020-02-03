using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Course_Entity.Migrations
{
    public partial class latestchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student Grades_Course",
                table: "Student Grades");

            migrationBuilder.CreateIndex(
                name: "IX_Student Grades_Course",
                table: "Student Grades",
                column: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student Grades_Course",
                table: "Student Grades");

            migrationBuilder.CreateIndex(
                name: "IX_Student Grades_Course",
                table: "Student Grades",
                column: "Course",
                unique: true);
        }
    }
}
