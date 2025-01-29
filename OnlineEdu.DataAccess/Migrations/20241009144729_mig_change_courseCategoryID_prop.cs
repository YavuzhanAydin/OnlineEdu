using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_change_courseCategoryID_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategories_CategoryID",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Courses",
                newName: "CourseCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryID",
                table: "Courses",
                newName: "IX_Courses_CourseCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategories_CourseCategoryID",
                table: "Courses",
                column: "CourseCategoryID",
                principalTable: "CourseCategories",
                principalColumn: "CourseCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategories_CourseCategoryID",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseCategoryID",
                table: "Courses",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseCategoryID",
                table: "Courses",
                newName: "IX_Courses_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategories_CategoryID",
                table: "Courses",
                column: "CategoryID",
                principalTable: "CourseCategories",
                principalColumn: "CourseCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
