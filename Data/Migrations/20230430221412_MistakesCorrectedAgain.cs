using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class MistakesCorrectedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_MedicalCards_MedicalCardNumberId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "MedicalCardNumberId",
                table: "Records",
                newName: "MedicalCardId");

            migrationBuilder.RenameColumn(
                name: "AppointmentDade",
                table: "Records",
                newName: "AppointmentDate");

            migrationBuilder.RenameIndex(
                name: "IX_Records_MedicalCardNumberId",
                table: "Records",
                newName: "IX_Records_MedicalCardId");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "MedicalCards",
                newName: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_MedicalCards_MedicalCardId",
                table: "Records",
                column: "MedicalCardId",
                principalTable: "MedicalCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_MedicalCards_MedicalCardId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "MedicalCardId",
                table: "Records",
                newName: "MedicalCardNumberId");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Records",
                newName: "AppointmentDade");

            migrationBuilder.RenameIndex(
                name: "IX_Records_MedicalCardId",
                table: "Records",
                newName: "IX_Records_MedicalCardNumberId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "MedicalCards",
                newName: "Adress");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_MedicalCards_MedicalCardNumberId",
                table: "Records",
                column: "MedicalCardNumberId",
                principalTable: "MedicalCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
