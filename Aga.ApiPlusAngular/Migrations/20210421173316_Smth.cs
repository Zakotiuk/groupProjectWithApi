using Microsoft.EntityFrameworkCore.Migrations;

namespace Aga.ApiPlusAngular.Migrations
{
    public partial class Smth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "tblTeacher");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "tblStudent");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "tblNews");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "tblGroup");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "tblCourse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTeacher",
                table: "tblTeacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStudent",
                table: "tblStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblNews",
                table: "tblNews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblGroup",
                table: "tblGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCourse",
                table: "tblCourse",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTeacher",
                table: "tblTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStudent",
                table: "tblStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblNews",
                table: "tblNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblGroup",
                table: "tblGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCourse",
                table: "tblCourse");

            migrationBuilder.RenameTable(
                name: "tblTeacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "tblStudent",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "tblNews",
                newName: "News");

            migrationBuilder.RenameTable(
                name: "tblGroup",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "tblCourse",
                newName: "Courses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");
        }
    }
}
