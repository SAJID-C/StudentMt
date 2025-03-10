using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class DB03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StdDeptAss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdDeptAss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StdDeptAss_Dept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Dept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StdDeptAss_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StdDeptAss_DeptId",
                table: "StdDeptAss",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_StdDeptAss_StudentId",
                table: "StdDeptAss",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StdDeptAss");
        }
    }
}
