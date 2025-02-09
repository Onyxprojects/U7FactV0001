using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U7Fact.Data.Migrations
{
    /// <inheritdoc />
    public partial class AanpassenFacturen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_BedrijfsKlanten_BedrijfsKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_ParticuliereKlanten_ParticuliereKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_BedrijfsKlanten_BedrijfsKlantId",
                table: "Offertes");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_ParticuliereKlanten_ParticuliereKlantId",
                table: "Offertes");

            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Facturen");

            migrationBuilder.AlterColumn<string>(
                name: "Referentie",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FactuurNummer",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferteId",
                table: "Facturen",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Facturen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExtraAanspreking",
                table: "BedrijfsKlanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraAchternaam",
                table: "BedrijfsKlanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraEmail",
                table: "BedrijfsKlanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraGsmnummer",
                table: "BedrijfsKlanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraTelefoonnummer",
                table: "BedrijfsKlanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraVoornaam",
                table: "BedrijfsKlanten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_OfferteId",
                table: "Facturen",
                column: "OfferteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_BedrijfsKlanten_BedrijfsKlantId",
                table: "Facturen",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen",
                column: "OfferteId",
                principalTable: "Offertes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_ParticuliereKlanten_ParticuliereKlantId",
                table: "Facturen",
                column: "ParticuliereKlantId",
                principalTable: "ParticuliereKlanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_BedrijfsKlanten_BedrijfsKlantId",
                table: "Offertes",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_ParticuliereKlanten_ParticuliereKlantId",
                table: "Offertes",
                column: "ParticuliereKlantId",
                principalTable: "ParticuliereKlanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_BedrijfsKlanten_BedrijfsKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_Offertes_OfferteId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_ParticuliereKlanten_ParticuliereKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_BedrijfsKlanten_BedrijfsKlantId",
                table: "Offertes");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_ParticuliereKlanten_ParticuliereKlantId",
                table: "Offertes");

            migrationBuilder.DropIndex(
                name: "IX_Facturen_OfferteId",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "FactuurNummer",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "OfferteId",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Facturen");

            migrationBuilder.DropColumn(
                name: "ExtraAanspreking",
                table: "BedrijfsKlanten");

            migrationBuilder.DropColumn(
                name: "ExtraAchternaam",
                table: "BedrijfsKlanten");

            migrationBuilder.DropColumn(
                name: "ExtraEmail",
                table: "BedrijfsKlanten");

            migrationBuilder.DropColumn(
                name: "ExtraGsmnummer",
                table: "BedrijfsKlanten");

            migrationBuilder.DropColumn(
                name: "ExtraTelefoonnummer",
                table: "BedrijfsKlanten");

            migrationBuilder.DropColumn(
                name: "ExtraVoornaam",
                table: "BedrijfsKlanten");

            migrationBuilder.AlterColumn<string>(
                name: "Referentie",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Facturen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_BedrijfsKlanten_BedrijfsKlantId",
                table: "Facturen",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlanten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_ParticuliereKlanten_ParticuliereKlantId",
                table: "Facturen",
                column: "ParticuliereKlantId",
                principalTable: "ParticuliereKlanten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_BedrijfsKlanten_BedrijfsKlantId",
                table: "Offertes",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlanten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_ParticuliereKlanten_ParticuliereKlantId",
                table: "Offertes",
                column: "ParticuliereKlantId",
                principalTable: "ParticuliereKlanten",
                principalColumn: "Id");
        }
    }
}
