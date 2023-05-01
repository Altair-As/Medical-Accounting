using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    public partial class MedicineTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Medicine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Medicine");
        }
    }
}
