using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoulMate.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soulmate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soulmate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soulmate_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 1, "IND", "India" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 2, "UK", "United Kingdoms" });

            migrationBuilder.InsertData(
                table: "Soulmate",
                columns: new[] { "Id", "Age", "CountryId", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 24, 2, "M", "Alpha" },
                    { 2, 25, 2, "M", "Beta" },
                    { 3, 23, 1, "F", "Charliee" },
                    { 4, 24, 1, "F", "zeta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soulmate_CountryId",
                table: "Soulmate",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Soulmate");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
