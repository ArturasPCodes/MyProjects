using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedreferencestoIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OngoingCourses_CourseId",
                table: "OngoingCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingCourseLines_LectorId",
                table: "OngoingCourseLines",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingCourseLines_OngoingCourseId",
                table: "OngoingCourseLines",
                column: "OngoingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OngoingCourseLines_StudentId",
                table: "OngoingCourseLines",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingCourseLines_Lectors_LectorId",
                table: "OngoingCourseLines",
                column: "LectorId",
                principalTable: "Lectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingCourseLines_OngoingCourses_OngoingCourseId",
                table: "OngoingCourseLines",
                column: "OngoingCourseId",
                principalTable: "OngoingCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingCourseLines_Students_StudentId",
                table: "OngoingCourseLines",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OngoingCourses_Courses_CourseId",
                table: "OngoingCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OngoingCourseLines_Lectors_LectorId",
                table: "OngoingCourseLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingCourseLines_OngoingCourses_OngoingCourseId",
                table: "OngoingCourseLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingCourseLines_Students_StudentId",
                table: "OngoingCourseLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OngoingCourses_Courses_CourseId",
                table: "OngoingCourses");

            migrationBuilder.DropIndex(
                name: "IX_OngoingCourses_CourseId",
                table: "OngoingCourses");

            migrationBuilder.DropIndex(
                name: "IX_OngoingCourseLines_LectorId",
                table: "OngoingCourseLines");

            migrationBuilder.DropIndex(
                name: "IX_OngoingCourseLines_OngoingCourseId",
                table: "OngoingCourseLines");

            migrationBuilder.DropIndex(
                name: "IX_OngoingCourseLines_StudentId",
                table: "OngoingCourseLines");
        }
    }
}
