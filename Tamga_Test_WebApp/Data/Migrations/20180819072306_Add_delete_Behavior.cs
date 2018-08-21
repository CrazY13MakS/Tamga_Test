using Microsoft.EntityFrameworkCore.Migrations;

namespace Tamga_Test_WebApp.Data.Migrations
{
    public partial class Add_delete_Behavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Positions_PositionId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ApplicantId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Positions_PositionId",
                table: "Applicants",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Positions_PositionId",
                table: "Applicants");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ApplicantId",
                table: "Employees",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Positions_PositionId",
                table: "Applicants",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
