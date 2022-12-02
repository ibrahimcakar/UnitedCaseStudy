using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitedCaseStudy.Data.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentNoteId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Notes_ParentNoteId",
                        column: x => x.ParentNoteId,
                        principalTable: "Notes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ParentNoteId",
                table: "Notes",
                column: "ParentNoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
