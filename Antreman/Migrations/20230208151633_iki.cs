using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antreman.Migrations
{
    /// <inheritdoc />
    public partial class iki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoritees",
                columns: table => new
                {
                    FavoriteeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserrID = table.Column<int>(type: "int", nullable: false),
                    FitnessCenterID = table.Column<int>(type: "int", nullable: false),
                    FavoriteeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritees", x => x.FavoriteeID);
                    table.ForeignKey(
                        name: "FK_Favoritees_FitnessCenters_FitnessCenterID",
                        column: x => x.FitnessCenterID,
                        principalTable: "FitnessCenters",
                        principalColumn: "FitnessCenterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritees_Userrs_UserrID",
                        column: x => x.UserrID,
                        principalTable: "Userrs",
                        principalColumn: "UserrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritees_FitnessCenterID",
                table: "Favoritees",
                column: "FitnessCenterID");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritees_UserrID",
                table: "Favoritees",
                column: "UserrID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritees");
        }
    }
}
