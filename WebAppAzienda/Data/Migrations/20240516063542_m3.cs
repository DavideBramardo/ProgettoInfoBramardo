using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAzienda.Data.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordine_Spedizione_SpedizioneIdSpedizione",
                table: "Ordine");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordine_Utente_UtenteId",
                table: "Ordine");

            migrationBuilder.DropIndex(
                name: "IX_Ordine_SpedizioneIdSpedizione",
                table: "Ordine");

            migrationBuilder.DropIndex(
                name: "IX_Ordine_UtenteId",
                table: "Ordine");

            migrationBuilder.DropColumn(
                name: "SpedizioneIdSpedizione",
                table: "Ordine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpedizioneIdSpedizione",
                table: "Ordine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_SpedizioneIdSpedizione",
                table: "Ordine",
                column: "SpedizioneIdSpedizione");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_UtenteId",
                table: "Ordine",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordine_Spedizione_SpedizioneIdSpedizione",
                table: "Ordine",
                column: "SpedizioneIdSpedizione",
                principalTable: "Spedizione",
                principalColumn: "IdSpedizione",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordine_Utente_UtenteId",
                table: "Ordine",
                column: "UtenteId",
                principalTable: "Utente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
