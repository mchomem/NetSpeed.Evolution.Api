using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_ActionPlain5W2H : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPlain5W2H",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CycleId = table.Column<long>(type: "bigint", nullable: false),
                    ImprovementPoint = table.Column<string>(type: "varchar(50)", nullable: false),
                    What = table.Column<string>(type: "varchar(50)", nullable: false),
                    Who = table.Column<string>(type: "varchar(50)", nullable: false),
                    Why = table.Column<string>(type: "varchar(50)", nullable: false),
                    Where = table.Column<string>(type: "varchar(50)", nullable: false),
                    When = table.Column<string>(type: "varchar(50)", nullable: false),
                    How = table.Column<string>(type: "varchar(200)", nullable: false),
                    HowMuch = table.Column<string>(type: "varchar(50)", nullable: false),
                    Observation = table.Column<string>(type: "varchar(1000)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlain5W2H", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlain_Cycle_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActionPlain_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain5W2H_CycleId",
                table: "ActionPlain5W2H",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain5W2H_EmployeeId",
                table: "ActionPlain5W2H",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionPlain5W2H");
        }
    }
}
