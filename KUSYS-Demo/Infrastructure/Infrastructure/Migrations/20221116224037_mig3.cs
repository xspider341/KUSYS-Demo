using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Course");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Student",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Course",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Course");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "Student",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "Course",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
