using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class RecordsTableModifiedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Records");
        }
    }
}
