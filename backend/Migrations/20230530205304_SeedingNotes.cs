using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedingNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Author", "CreatedDate", "EditedDate", "Heading", "Text" },
                values: new object[,]
                {
                    { 1, "Antonin Dvorak", new DateTime(2023, 5, 30, 22, 53, 4, 168, DateTimeKind.Local).AddTicks(4447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Note", "Detailsaf nejfqo qnfwk qwfn qwf qn" },
                    { 2, "Bedrich Smetana", new DateTime(2023, 5, 30, 22, 53, 4, 168, DateTimeKind.Local).AddTicks(4580), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Note", "Detailsaf nejfqo qnfwk qwfn qwf qn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_NoteId",
                table: "Tag",
                column: "NoteId");
        }
    }
}
