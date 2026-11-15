using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPM.Tourism.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTourismContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourismContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Typology = table.Column<string>(type: "TEXT", nullable: true),
                    Municipality = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourismContents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourismContents_Category_ExternalId",
                table: "TourismContents",
                columns: new[] { "Category", "ExternalId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourismContents");
        }
    }
}
