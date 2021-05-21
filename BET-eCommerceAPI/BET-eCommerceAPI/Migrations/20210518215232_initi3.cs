using Microsoft.EntityFrameworkCore.Migrations;

namespace BET_eCommerceAPI.Migrations
{
    public partial class initi3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Department_Department_ID",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Department_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Departments_Department_ID",
                table: "Categories",
                column: "Department_ID",
                principalTable: "Departments",
                principalColumn: "Department_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Departments_Department_ID",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Department_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Department_Department_ID",
                table: "Categories",
                column: "Department_ID",
                principalTable: "Department",
                principalColumn: "Department_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
