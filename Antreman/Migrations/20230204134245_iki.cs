using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Antreman.Migrations
{
    /// <inheritdoc />
    public partial class iki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rolees",
                columns: table => new
                {
                    RoleeID = table.Column<byte>(type: "tinyint", nullable: false),
                    RoleeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolees", x => x.RoleeID);
                });

            migrationBuilder.CreateTable(
                name: "Userrs",
                columns: table => new
                {
                    UserrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleeID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userrs", x => x.UserrID);
                    table.ForeignKey(
                        name: "FK_Userrs_Rolees_RoleeID",
                        column: x => x.RoleeID,
                        principalTable: "Rolees",
                        principalColumn: "RoleeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rolees",
                columns: new[] { "RoleeID", "RoleeName" },
                values: new object[,]
                {
                    { (byte)1, "Aday" },
                    { (byte)2, "Uye" },
                    { (byte)3, "Admin" },
                    { (byte)4, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Userrs",
                columns: new[] { "UserrID", "Email", "Password", "RoleeID" },
                values: new object[,]
                {
                    { 1, "aday@gmail.com", "123456", (byte)1 },
                    { 2, "uye@gmail.com", "123456", (byte)2 },
                    { 3, "uye2@gmail.com", "123456", (byte)2 },
                    { 4, "admin@gmail.com", "123456", (byte)3 },
                    { 5, "supervisor@gmail.com", "123456", (byte)4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Userrs_RoleeID",
                table: "Userrs",
                column: "RoleeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userrs");

            migrationBuilder.DropTable(
                name: "Rolees");
        }
    }
}
