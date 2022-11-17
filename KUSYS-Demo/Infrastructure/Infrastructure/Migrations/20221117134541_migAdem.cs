using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class migAdem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CourseId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Course");
        }
    }
}
