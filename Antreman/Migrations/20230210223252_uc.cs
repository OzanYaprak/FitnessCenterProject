using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antreman.Migrations
{
    /// <inheritdoc />
    public partial class uc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentts",
                columns: table => new
                {
                    CommenttID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessCenterID = table.Column<int>(type: "int", nullable: false),
                    CommenttDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserrID = table.Column<int>(type: "int", nullable: false),
                    CommenttText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentts", x => x.CommenttID);
                    table.ForeignKey(
                        name: "FK_Commentts_FitnessCenters_FitnessCenterID",
                        column: x => x.FitnessCenterID,
                        principalTable: "FitnessCenters",
                        principalColumn: "FitnessCenterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentts_Userrs_UserrID",
                        column: x => x.UserrID,
                        principalTable: "Userrs",
                        principalColumn: "UserrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentts_FitnessCenterID",
                table: "Commentts",
                column: "FitnessCenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Commentts_UserrID",
                table: "Commentts",
                column: "UserrID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentts");
        }
    }
}
