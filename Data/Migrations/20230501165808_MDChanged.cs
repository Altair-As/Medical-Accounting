using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class MDChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MDs_EmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_MDs_MDId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MDs",
                table: "MDs");

            migrationBuilder.RenameTable(
                name: "MDs",
                newName: "Employers");

            migrationBuilder.RenameColumn(
                name: "MDId",
                table: "Records",
                newName: "EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_MDId",
                table: "Records",
                newName: "IX_Records_EmployerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employers",
                table: "Employers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employers_EmployerId",
                table: "AspNetUsers",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Employers_EmployerId",
                table: "Records",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employers_EmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Employers_EmployerId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employers",
                table: "Employers");

            migrationBuilder.RenameTable(
                name: "Employers",
                newName: "MDs");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "Records",
                newName: "MDId");

            migrationBuilder.RenameIndex(
                name: "IX_Records_EmployerId",
                table: "Records",
                newName: "IX_Records_MDId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MDs",
                table: "MDs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MDs_EmployerId",
                table: "AspNetUsers",
                column: "EmployerId",
                principalTable: "MDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_MDs_MDId",
                table: "Records",
                column: "MDId",
                principalTable: "MDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
