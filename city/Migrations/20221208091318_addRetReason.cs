using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace city.Migrations
{
    /// <inheritdoc />
    public partial class addRetReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RetReason",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpCode = table.Column<int>(name: "Emp_Code", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetReason", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetReason");
        }
    }
}
