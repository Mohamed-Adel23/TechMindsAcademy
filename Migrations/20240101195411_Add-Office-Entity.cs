using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTut.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Instructors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offices", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfficeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LName", "OfficeId" },
                values: new object[] { "Shawky", 3 });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfficeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfficeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfficeId",
                value: 5);

            migrationBuilder.InsertData(
                table: "offices",
                columns: new[] { "Id", "OfficeLocation", "OfficeName" },
                values: new object[,]
                {
                    { 1, "building A", "Off_05" },
                    { 2, "building B", "Off_12" },
                    { 3, "Adminstration", "Off_32" },
                    { 4, "IT Department", "Off_44" },
                    { 5, "IT Department", "Off_43" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_OfficeId",
                table: "Instructors",
                column: "OfficeId",
                unique: true,
                filter: "[OfficeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_offices_OfficeId",
                table: "Instructors",
                column: "OfficeId",
                principalTable: "offices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_offices_OfficeId",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "offices");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_OfficeId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Instructors");

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "LName",
                value: "Yasmeen");
        }
    }
}
