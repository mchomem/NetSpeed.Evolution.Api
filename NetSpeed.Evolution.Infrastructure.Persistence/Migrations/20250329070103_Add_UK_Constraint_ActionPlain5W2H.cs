using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_UK_Constraint_ActionPlain5W2H : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActionPlain5W2H_EmployeeId",
                table: "ActionPlain5W2H");

            migrationBuilder.CreateIndex(
                name: "UK_ActionPlain5W2H_EmployeeId_CycleId",
                table: "ActionPlain5W2H",
                columns: new[] { "EmployeeId", "CycleId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_ActionPlain5W2H_EmployeeId_CycleId",
                table: "ActionPlain5W2H");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain5W2H_EmployeeId",
                table: "ActionPlain5W2H",
                column: "EmployeeId");
        }
    }
}
