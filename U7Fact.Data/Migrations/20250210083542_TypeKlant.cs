using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace U7Fact.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypeKlant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Klanten_Klantnummer",
                table: "Klanten");

            migrationBuilder.AlterColumn<string>(
                name: "Klantnummer",
                table: "Klanten",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Klantnummer",
                table: "Klanten",
                column: "Klantnummer",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Klanten_Klantnummer",
                table: "Klanten");

            migrationBuilder.AlterColumn<string>(
                name: "Klantnummer",
                table: "Klanten",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Klantnummer",
                table: "Klanten",
                column: "Klantnummer",
                unique: true,
                filter: "[Klantnummer] IS NOT NULL");
        }
    }
}
