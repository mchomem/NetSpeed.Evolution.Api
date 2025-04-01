using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Constraints_ActionPlain5W2H : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlain_Cycle_CycleId",
                table: "ActionPlain5W2H");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlain_Employee_EmployeeId",
                table: "ActionPlain5W2H");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlain5W2H_Cycle_CycleId",
                table: "ActionPlain5W2H",
                column: "CycleId",
                principalTable: "Cycle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlain5W2H_Employee_EmployeeId",
                table: "ActionPlain5W2H",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlain5W2H_Cycle_CycleId",
                table: "ActionPlain5W2H");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionPlain5W2H_Employee_EmployeeId",
                table: "ActionPlain5W2H");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlain_Cycle_CycleId",
                table: "ActionPlain5W2H",
                column: "CycleId",
                principalTable: "Cycle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPlain_Employee_EmployeeId",
                table: "ActionPlain5W2H",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
