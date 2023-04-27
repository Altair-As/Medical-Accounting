using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class MedicineTableAddedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineRecord",
                columns: table => new
                {
                    MedicationsId = table.Column<int>(type: "int", nullable: false),
                    RecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineRecord", x => new { x.MedicationsId, x.RecordsId });
                    table.ForeignKey(
                        name: "FK_MedicineRecord_Medicine_MedicationsId",
                        column: x => x.MedicationsId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineRecord_Records_RecordsId",
                        column: x => x.RecordsId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineRecord_RecordsId",
                table: "MedicineRecord",
                column: "RecordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineRecord");

            migrationBuilder.DropTable(
                name: "Medicine");
        }
    }
}
