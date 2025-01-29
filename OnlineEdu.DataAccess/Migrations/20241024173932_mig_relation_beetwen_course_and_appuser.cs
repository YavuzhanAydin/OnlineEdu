using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_relation_beetwen_course_and_appuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseRegisters",
                columns: table => new
                {
                    CourseRegisterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegisters", x => x.CourseRegisterID);
                    table.ForeignKey(
                        name: "FK_CourseRegisters_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRegisters_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AppUserID",
                table: "Courses",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_AppUserID",
                table: "CourseRegisters",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_CourseID",
                table: "CourseRegisters",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AppUserID",
                table: "Courses",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AppUserID",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseRegisters");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AppUserID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Courses");
        }
    }
}
