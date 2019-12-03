using Microsoft.EntityFrameworkCore.Migrations;

namespace Life_In_Notes.Migrations
{
    public partial class UpdateNoteClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notes",
                newName: "EntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "Notes",
                newName: "UserId");
        }
    }
}
