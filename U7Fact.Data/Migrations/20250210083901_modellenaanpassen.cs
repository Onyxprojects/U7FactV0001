using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U7Fact.Data.Migrations
{
    /// <inheritdoc />
    public partial class modellenaanpassen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_BedrijfsKlant_BedrijfsKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturen_ParticuliereKlant_ParticuliereKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_BedrijfsKlant_BedrijfsKlantId",
                table: "Offertes");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_ParticuliereKlant_ParticuliereKlantId",
                table: "Offertes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticuliereKlant",
                table: "ParticuliereKlant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BedrijfsKlant",
                table: "BedrijfsKlant");

            migrationBuilder.RenameTable(
                name: "ParticuliereKlant",
                newName: "ParticuliereKlanten");

            migrationBuilder.RenameTable(
                name: "BedrijfsKlant",
                newName: "BedrijfsKlanten");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticuliereKlanten",
                table: "ParticuliereKlanten",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BedrijfsKlanten",
                table: "BedrijfsKlanten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_BedrijfsKlanten_BedrijfsKlantId",
                table: "Facturen",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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
                name: "FK_Facturen_ParticuliereKlanten_ParticuliereKlantId",
                table: "Facturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_BedrijfsKlanten_BedrijfsKlantId",
                table: "Offertes");

            migrationBuilder.DropForeignKey(
                name: "FK_Offertes_ParticuliereKlanten_ParticuliereKlantId",
                table: "Offertes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticuliereKlanten",
                table: "ParticuliereKlanten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BedrijfsKlanten",
                table: "BedrijfsKlanten");

            migrationBuilder.RenameTable(
                name: "ParticuliereKlanten",
                newName: "ParticuliereKlant");

            migrationBuilder.RenameTable(
                name: "BedrijfsKlanten",
                newName: "BedrijfsKlant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticuliereKlant",
                table: "ParticuliereKlant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BedrijfsKlant",
                table: "BedrijfsKlant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_BedrijfsKlant_BedrijfsKlantId",
                table: "Facturen",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlant",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturen_ParticuliereKlant_ParticuliereKlantId",
                table: "Facturen",
                column: "ParticuliereKlantId",
                principalTable: "ParticuliereKlant",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_BedrijfsKlant_BedrijfsKlantId",
                table: "Offertes",
                column: "BedrijfsKlantId",
                principalTable: "BedrijfsKlant",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Offertes_ParticuliereKlant_ParticuliereKlantId",
                table: "Offertes",
                column: "ParticuliereKlantId",
                principalTable: "ParticuliereKlant",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
