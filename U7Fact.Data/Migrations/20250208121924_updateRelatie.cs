using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U7Fact.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateRelatie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "RelatieSequence");

            migrationBuilder.CreateTable(
                name: "BedrijfsKlanten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [RelatieSequence]"),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klantnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gsmnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Straatnaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterneNotitie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BtwNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bedrijfsnaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AansprekingContactpersoon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KboNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achtervoegsel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedrijfsKlanten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticuliereKlanten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [RelatieSequence]"),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klantnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gsmnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Straatnaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterneNotitie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aanspreking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraAanspreking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraVoornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraAchternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraTelefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraGsmnummer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticuliereKlanten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referentie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactuurDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerzendDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Betalingstermijn = table.Column<int>(type: "int", nullable: true),
                    Verzendmetode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterneNotitie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LosseBijlage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedrijfsKlantId = table.Column<int>(type: "int", nullable: true),
                    ParticuliereKlantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_BedrijfsKlanten_BedrijfsKlantId",
                        column: x => x.BedrijfsKlantId,
                        principalTable: "BedrijfsKlanten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facturen_ParticuliereKlanten_ParticuliereKlantId",
                        column: x => x.ParticuliereKlantId,
                        principalTable: "ParticuliereKlanten",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offertes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referentie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerzendDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Geldigheidsduur = table.Column<int>(type: "int", nullable: true),
                    Verzendmetode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterneNotitie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LosseBijlage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedrijfsKlantId = table.Column<int>(type: "int", nullable: true),
                    ParticuliereKlantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offertes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offertes_BedrijfsKlanten_BedrijfsKlantId",
                        column: x => x.BedrijfsKlantId,
                        principalTable: "BedrijfsKlanten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offertes_ParticuliereKlanten_ParticuliereKlantId",
                        column: x => x.ParticuliereKlantId,
                        principalTable: "ParticuliereKlanten",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_BedrijfsKlantId",
                table: "Facturen",
                column: "BedrijfsKlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_ParticuliereKlantId",
                table: "Facturen",
                column: "ParticuliereKlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Offertes_BedrijfsKlantId",
                table: "Offertes",
                column: "BedrijfsKlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Offertes_ParticuliereKlantId",
                table: "Offertes",
                column: "ParticuliereKlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "Offertes");

            migrationBuilder.DropTable(
                name: "BedrijfsKlanten");

            migrationBuilder.DropTable(
                name: "ParticuliereKlanten");

            migrationBuilder.DropSequence(
                name: "RelatieSequence");
        }
    }
}
