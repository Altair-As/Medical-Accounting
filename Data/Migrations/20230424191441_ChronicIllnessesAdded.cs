using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class ChronicIllnessesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChronicIllnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicIllnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChronicIllnessMedicalCard",
                columns: table => new
                {
                    IllnessesId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicIllnessMedicalCard", x => new { x.IllnessesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_ChronicIllnessMedicalCard_ChronicIllnesses_IllnessesId",
                        column: x => x.IllnessesId,
                        principalTable: "ChronicIllnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChronicIllnessMedicalCard_MedicalCards_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "MedicalCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChronicIllnessMedicalCard_PatientsId",
                table: "ChronicIllnessMedicalCard",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChronicIllnessMedicalCard");

            migrationBuilder.DropTable(
                name: "ChronicIllnesses");
        }
    }
}
