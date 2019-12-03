using Microsoft.EntityFrameworkCore.Migrations;

namespace Life_In_Notes.Migrations
{
    public partial class UpdateEntryClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Entries",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Entries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Content", "Date", "Name", "RefDate", "Theme", "Type", "UserId" },
                values: new object[] { 13, "I do not know why I like the number 13.", "2019-12-11", "This is my favorite Number", "0000-00-00", 6, 4, 13 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Content", "Date", "Name", "RefDate", "Theme", "Type", "UserId" },
                values: new object[] { 12, "12 is an interesting number.", "2019-09-11", "What does 12 have to do with it?", "0000-00-00", 6, 4, 13 });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Content", "Date", "Name", "RefDate", "Theme", "Type", "UserId" },
                values: new object[] { 11, "There is something satisfying about coding.", "2019-08-11", "I do enjoy coding.", "0000-00-00", 11, 5, 13 });
        }
    }
}
