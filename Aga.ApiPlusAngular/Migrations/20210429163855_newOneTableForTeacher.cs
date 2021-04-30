using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aga.ApiPlusAngular.Migrations
{
    public partial class newOneTableForTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblHomework",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    idTeacher = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHomework", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLesson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    idTeacher = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblReward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReward", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblStundetReward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStudentId = table.Column<int>(nullable: true),
                    IdRewardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStundetReward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblStundetReward_tblReward_IdRewardId",
                        column: x => x.IdRewardId,
                        principalTable: "tblReward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblStundetReward_tblStudent_IdStudentId",
                        column: x => x.IdStudentId,
                        principalTable: "tblStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblStundetReward_IdRewardId",
                table: "tblStundetReward",
                column: "IdRewardId");

            migrationBuilder.CreateIndex(
                name: "IX_tblStundetReward_IdStudentId",
                table: "tblStundetReward",
                column: "IdStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblHomework");

            migrationBuilder.DropTable(
                name: "tblLesson");

            migrationBuilder.DropTable(
                name: "tblStundetReward");

            migrationBuilder.DropTable(
                name: "tblReward");
        }
    }
}
