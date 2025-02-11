using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U7Fact.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aanspreking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klantnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    KlantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraAanspreking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraVoornaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraAchternaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraTelefoonnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraGsmnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bedrijfsnaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AansprekingContactpersoon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BtwNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KboNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achtervoegsel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
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
                    KlantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offertes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offertes_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactuurNummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referentie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FactuurDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerzendDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Betalingstermijn = table.Column<int>(type: "int", nullable: true),
                    Verzendmetode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterneNotitie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LosseBijlage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlantId = table.Column<int>(type: "int", nullable: true),
                    OfferteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Facturen_Offertes_OfferteId",
                        column: x => x.OfferteId,
                        principalTable: "Offertes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_KlantId",
                table: "Facturen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_OfferteId",
                table: "Facturen",
                column: "OfferteId");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Klantnummer",
                table: "Klanten",
                column: "Klantnummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offertes_KlantId",
                table: "Offertes",
                column: "KlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "Offertes");

            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
