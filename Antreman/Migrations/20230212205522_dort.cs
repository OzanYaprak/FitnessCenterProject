using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Antreman.Migrations
{
    /// <inheritdoc />
    public partial class dort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerNameAndSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerID);
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "TrainerID", "TrainerNameAndSurname" },
                values: new object[,]
                {
                    { 1, "Aslı Hisar" },
                    { 2, "Ogün Güçlü" },
                    { 3, "Melis Yaprak" },
                    { 4, "Ayça Güneri" },
                    { 5, "Zuhal Gün" },
                    { 6, "Ali Koyun" },
                    { 7, "Hakan Taşıyıcı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
