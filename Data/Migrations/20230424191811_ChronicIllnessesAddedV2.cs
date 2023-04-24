using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class ChronicIllnessesAddedV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronicIllnessMedicalCard_MedicalCards_PatientsId",
                table: "ChronicIllnessMedicalCard");

            migrationBuilder.RenameColumn(
                name: "PatientsId",
                table: "ChronicIllnessMedicalCard",
                newName: "MedicalCardsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChronicIllnessMedicalCard_PatientsId",
                table: "ChronicIllnessMedicalCard",
                newName: "IX_ChronicIllnessMedicalCard_MedicalCardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChronicIllnessMedicalCard_MedicalCards_MedicalCardsId",
                table: "ChronicIllnessMedicalCard",
                column: "MedicalCardsId",
                principalTable: "MedicalCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronicIllnessMedicalCard_MedicalCards_MedicalCardsId",
                table: "ChronicIllnessMedicalCard");

            migrationBuilder.RenameColumn(
                name: "MedicalCardsId",
                table: "ChronicIllnessMedicalCard",
                newName: "PatientsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChronicIllnessMedicalCard_MedicalCardsId",
                table: "ChronicIllnessMedicalCard",
                newName: "IX_ChronicIllnessMedicalCard_PatientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChronicIllnessMedicalCard_MedicalCards_PatientsId",
                table: "ChronicIllnessMedicalCard",
                column: "PatientsId",
                principalTable: "MedicalCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
