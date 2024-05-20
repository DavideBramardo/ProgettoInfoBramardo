using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAzienda.Data.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotto_Ordine_OrdineId",
                table: "Prodotto");

            migrationBuilder.DropIndex(
                name: "IX_Prodotto_OrdineId",
                table: "Prodotto");

            migrationBuilder.DropColumn(
                name: "OrdineId",
                table: "Prodotto");

            migrationBuilder.AddColumn<string>(
                name: "DescrProdotti",
                table: "Ordine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescrProdotti",
                table: "Ordine");

            migrationBuilder.AddColumn<int>(
                name: "OrdineId",
                table: "Prodotto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotto_OrdineId",
                table: "Prodotto",
                column: "OrdineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotto_Ordine_OrdineId",
                table: "Prodotto",
                column: "OrdineId",
                principalTable: "Ordine",
                principalColumn: "Id");
        }
    }
}
