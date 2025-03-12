using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Employee_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UK_Employee_RegistrationNumber",
                table: "Employee",
                column: "RegistrationNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Employee_RegistrationNumber",
                table: "Employee");
        }
    }
}
