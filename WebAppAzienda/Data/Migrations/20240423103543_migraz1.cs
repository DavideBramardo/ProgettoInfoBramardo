using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAzienda.Data.Migrations
{
    /// <inheritdoc />
    public partial class migraz1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spedizione",
                columns: table => new
                {
                    IdSpedizione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdine = table.Column<int>(type: "int", nullable: false),
                    DataSpedizione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IndirizzoSpedizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedizione", x => x.IdSpedizione);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NTelefonico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    SpedizioneIdSpedizione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordine_Spedizione_SpedizioneIdSpedizione",
                        column: x => x.SpedizioneIdSpedizione,
                        principalTable: "Spedizione",
                        principalColumn: "IdSpedizione",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordine_Utente_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prodotto",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredienti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrdineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodotto_Ordine_OrdineId",
                        column: x => x.OrdineId,
                        principalTable: "Ordine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_SpedizioneIdSpedizione",
                table: "Ordine",
                column: "SpedizioneIdSpedizione");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_UtenteId",
                table: "Ordine",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotto_OrdineId",
                table: "Prodotto",
                column: "OrdineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodotto");

            migrationBuilder.DropTable(
                name: "Ordine");

            migrationBuilder.DropTable(
                name: "Spedizione");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
