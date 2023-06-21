using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesList.Migrations
{
    public partial class fixFieldEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Employee_EmployeeId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Employee_EmployeeId",
                table: "Children",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Employee_EmployeeId",
                table: "Children");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Children",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Employee_EmployeeId",
                table: "Children",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
