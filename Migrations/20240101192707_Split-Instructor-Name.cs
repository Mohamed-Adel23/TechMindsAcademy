using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTut.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SplitInstructorName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instructors",
                newName: "FName");

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Ahmed", "Abdullah" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "FName",
                value: "Yasmeen");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Khalid", "Hassan" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Nadia", "Ali" });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Ahmed", "Abdullah" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FName",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Instructors",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ahmed");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Khalid");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Nadia");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Ahmed");
        }
    }
}
