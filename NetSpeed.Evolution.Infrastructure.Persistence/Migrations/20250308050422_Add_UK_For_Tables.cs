using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_UK_For_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UK_JobTitle_Name",
                table: "JobTitle",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_HardSkill_Name",
                table: "HardSkill",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_JobTitle_Name",
                table: "JobTitle");

            migrationBuilder.DropIndex(
                name: "UK_HardSkill_Name",
                table: "HardSkill");

            migrationBuilder.DropIndex(
                name: "UK_Department_Name",
                table: "Department");
        }
    }
}
