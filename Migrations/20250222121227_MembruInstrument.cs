using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicSchoolWEB.Migrations
{
    /// <inheritdoc />
    public partial class MembruInstrument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembruInstrument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruID = table.Column<int>(type: "int", nullable: true),
                    InstrumentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembruInstrument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MembruInstrument_Instrument_InstrumentID",
                        column: x => x.InstrumentID,
                        principalTable: "Instrument",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MembruInstrument_Membru_MembruID",
                        column: x => x.MembruID,
                        principalTable: "Membru",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembruInstrument_InstrumentID",
                table: "MembruInstrument",
                column: "InstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_MembruInstrument_MembruID",
                table: "MembruInstrument",
                column: "MembruID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembruInstrument");
        }
    }
}
