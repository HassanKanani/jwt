using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseApi.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserT",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserT", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "UserT",
                columns: new[] { "id", "address", "age", "name", "role" },
                values: new object[,]
                {
                    { 1L, "tehran", 27, "kananiHassan", false },
                    { 2L, "Ahvaz", 14, "Aref", false },
                    { 3L, "Khorasan", 17, "Ali", false },
                    { 4L, "iran", 23, "Mehdi", false },
                    { 5L, "boujnord", 25, "Reza", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserT");
        }
    }
}
