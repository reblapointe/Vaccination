using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vaccination.Migrations
{
    /// <inheritdoc />
    public partial class Immunisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccins",
                columns: table => new
                {
                    VaccinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccins", x => x.VaccinId);
                });

            migrationBuilder.CreateTable(
                name: "Immunisations",
                columns: table => new
                {
                    ImmunisationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NAMPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NomVariant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstSevere = table.Column<bool>(type: "bit", nullable: true),
                    DoseId = table.Column<int>(type: "int", nullable: true),
                    VaccinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immunisations", x => x.ImmunisationId);
                    table.ForeignKey(
                        name: "FK_Immunisations_Vaccins_VaccinId",
                        column: x => x.VaccinId,
                        principalTable: "Vaccins",
                        principalColumn: "VaccinId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Immunisations_VaccinId",
                table: "Immunisations",
                column: "VaccinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Immunisations");

            migrationBuilder.DropTable(
                name: "Vaccins");
        }
    }
}
