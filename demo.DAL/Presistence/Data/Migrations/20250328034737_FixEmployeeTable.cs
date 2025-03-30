using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo.DAL.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeS",
                table: "EmployeeS");

            migrationBuilder.RenameTable(
                name: "EmployeeS",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EmployeeS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeS",
                table: "EmployeeS",
                column: "Id");
        }
    }
}
