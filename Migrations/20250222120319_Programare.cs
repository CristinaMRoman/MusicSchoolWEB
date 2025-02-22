using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchoolWEB.Migrations
{
    /// <inheritdoc />
    public partial class Programare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    OraProgramarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresaProgramarii = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Membru_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Membru",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Membru_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Membru",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_StudentID",
                table: "Programare",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_TeacherID",
                table: "Programare",
                column: "TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");
        }
    }
}
