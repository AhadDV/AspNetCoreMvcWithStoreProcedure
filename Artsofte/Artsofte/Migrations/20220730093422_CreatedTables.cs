using Microsoft.EntityFrameworkCore.Migrations;

namespace Artsofte.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Floor = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDatasFromDb",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeSurname = table.Column<string>(nullable: true),
                    EmployeeAge = table.Column<byte>(nullable: false),
                    EmployeeGender = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    ProgrammingLanguageName = table.Column<string>(nullable: true),
                    ProgrammingLanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProgramingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramingLanguages_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: false),
                    Age = table.Column<byte>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProgramingLanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_ProgramingLanguages_ProgramingLanguageId",
                        column: x => x.ProgramingLanguageId,
                        principalTable: "ProgramingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProgramingLanguageId",
                table: "Employees",
                column: "ProgramingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramingLanguages_DepartmentId",
                table: "ProgramingLanguages",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDatasFromDb");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProgramingLanguages");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
