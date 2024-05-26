using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_redevances_perimetres_perimetreId",
                table: "redevances");

            migrationBuilder.DropForeignKey(
                name: "FK_redevances_produits_ProduitId",
                table: "redevances");

            migrationBuilder.DropForeignKey(
                name: "FK_trps_redevances_productionidRdv",
                table: "trps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_redevances",
                table: "redevances");

            migrationBuilder.RenameTable(
                name: "redevances",
                newName: "productions");

            migrationBuilder.RenameIndex(
                name: "IX_redevances_ProduitId",
                table: "productions",
                newName: "IX_productions_ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_redevances_perimetreId",
                table: "productions",
                newName: "IX_productions_perimetreId");

            migrationBuilder.AddColumn<decimal>(
                name: "qteProduite",
                table: "productions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productions",
                table: "productions",
                column: "idRdv");

            migrationBuilder.AddForeignKey(
                name: "FK_productions_perimetres_perimetreId",
                table: "productions",
                column: "perimetreId",
                principalTable: "perimetres",
                principalColumn: "idPerimetre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productions_produits_ProduitId",
                table: "productions",
                column: "ProduitId",
                principalTable: "produits",
                principalColumn: "idProduit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trps_productions_productionidRdv",
                table: "trps",
                column: "productionidRdv",
                principalTable: "productions",
                principalColumn: "idRdv",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productions_perimetres_perimetreId",
                table: "productions");

            migrationBuilder.DropForeignKey(
                name: "FK_productions_produits_ProduitId",
                table: "productions");

            migrationBuilder.DropForeignKey(
                name: "FK_trps_productions_productionidRdv",
                table: "trps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productions",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "qteProduite",
                table: "productions");

            migrationBuilder.RenameTable(
                name: "productions",
                newName: "redevances");

            migrationBuilder.RenameIndex(
                name: "IX_productions_ProduitId",
                table: "redevances",
                newName: "IX_redevances_ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_productions_perimetreId",
                table: "redevances",
                newName: "IX_redevances_perimetreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_redevances",
                table: "redevances",
                column: "idRdv");

            migrationBuilder.AddForeignKey(
                name: "FK_redevances_perimetres_perimetreId",
                table: "redevances",
                column: "perimetreId",
                principalTable: "perimetres",
                principalColumn: "idPerimetre",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_redevances_produits_ProduitId",
                table: "redevances",
                column: "ProduitId",
                principalTable: "produits",
                principalColumn: "idProduit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trps_redevances_productionidRdv",
                table: "trps",
                column: "productionidRdv",
                principalTable: "redevances",
                principalColumn: "idRdv",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
