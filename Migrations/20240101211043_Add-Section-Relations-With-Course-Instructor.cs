using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTut.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddSectionRelationsWithCourseInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_offices_OfficeId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_offices",
                table: "offices");

            migrationBuilder.RenameTable(
                name: "offices",
                newName: "Offices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offices",
                table: "Offices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "InstructorId", "SectionName" },
                values: new object[,]
                {
                    { 1, 1, 1, "S_MA1" },
                    { 2, 1, 2, "S_MA2" },
                    { 3, 2, 1, "S_PH1" },
                    { 4, 2, 3, "S_PH2" },
                    { 5, 3, 2, "S_CH1" },
                    { 6, 3, 3, "S_CH2" },
                    { 7, 4, 4, "S_BI1" },
                    { 8, 4, 5, "S_BI2" },
                    { 9, 5, 4, "S_CS1" },
                    { 10, 5, 5, "S_CS2" },
                    { 11, 5, 4, "S_CS3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_InstructorId",
                table: "Sections",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Offices_OfficeId",
                table: "Instructors",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Offices_OfficeId",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offices",
                table: "Offices");

            migrationBuilder.RenameTable(
                name: "Offices",
                newName: "offices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_offices",
                table: "offices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_offices_OfficeId",
                table: "Instructors",
                column: "OfficeId",
                principalTable: "offices",
                principalColumn: "Id");
        }
    }
}
