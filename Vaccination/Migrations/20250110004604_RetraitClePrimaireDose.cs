using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vaccination.Migrations
{
    /// <inheritdoc />
    public partial class RetraitClePrimaireDose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoseId",
                table: "Immunisations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoseId",
                table: "Immunisations",
                type: "int",
                nullable: true);
        }
    }
}
