using Microsoft.EntityFrameworkCore.Migrations;

namespace Tamga_Test_WebApp.Data.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PretendetSalary",
                table: "Applicants",
                newName: "PretendedSalary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PretendedSalary",
                table: "Applicants",
                newName: "PretendetSalary");
        }
    }
}
