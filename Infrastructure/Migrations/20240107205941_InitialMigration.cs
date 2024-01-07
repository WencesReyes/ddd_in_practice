using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnackMachines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneCentCount = table.Column<int>(type: "int", nullable: false),
                    TenCentCount = table.Column<int>(type: "int", nullable: false),
                    QuarterCount = table.Column<int>(type: "int", nullable: false),
                    OneDollarCount = table.Column<int>(type: "int", nullable: false),
                    FiveDollarCount = table.Column<int>(type: "int", nullable: false),
                    TwentyDollarCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackMachines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnackMachines");
        }
    }
}
