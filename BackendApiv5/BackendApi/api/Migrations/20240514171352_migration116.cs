using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class migration116 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "investissements",
                columns: table => new
                {
                    idInvest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    montantInvest = table.Column<float>(type: "real", nullable: false),
                    typeInvest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateInvet = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_investissements", x => x.idInvest);
                });

            migrationBuilder.CreateTable(
                name: "monnaies",
                columns: table => new
                {
                    idMonnaie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tauxChange = table.Column<float>(type: "real", nullable: false),
                    dateModificationMonnaie = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monnaies", x => x.idMonnaie);
                });

            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    idProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomProduit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.idProduit);
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    idZone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    localisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.idZone);
                });

            migrationBuilder.CreateTable(
                name: "prixBases",
                columns: table => new
                {
                    idPb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prixBase = table.Column<float>(type: "real", nullable: false),
                    dateModificationPb = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prixBases", x => x.idPb);
                    table.ForeignKey(
                        name: "FK_prixBases_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "idProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prixMns",
                columns: table => new
                {
                    idPMn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prixMn = table.Column<float>(type: "real", nullable: false),
                    datemodificationPmn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prixMns", x => x.idPMn);
                    table.ForeignKey(
                        name: "FK_prixMns_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "idProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tarifTransports",
                columns: table => new
                {
                    idTt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarifTransport = table.Column<float>(type: "real", nullable: false),
                    dateModificationTt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarifTransports", x => x.idTt);
                    table.ForeignKey(
                        name: "FK_tarifTransports_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "idProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perimetres",
                columns: table => new
                {
                    idPerimetre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomPerimetre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    associative = table.Column<bool>(type: "bit", nullable: false),
                    qteGaz = table.Column<float>(type: "real", nullable: false),
                    wilaya = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perimetres", x => x.idPerimetre);
                    table.ForeignKey(
                        name: "FK_perimetres_zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "zones",
                        principalColumn: "idZone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "declarationRedevances",
                columns: table => new
                {
                    idDeclaration = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TauxRdv = table.Column<float>(type: "real", nullable: false),
                    BaseRdv = table.Column<float>(type: "real", nullable: false),
                    montantRdv = table.Column<float>(type: "real", nullable: false),
                    typeRdv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateRdv = table.Column<DateOnly>(type: "date", nullable: false),
                    perimetreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_declarationRedevances", x => x.idDeclaration);
                    table.ForeignKey(
                        name: "FK_declarationRedevances_perimetres_perimetreId",
                        column: x => x.perimetreId,
                        principalTable: "perimetres",
                        principalColumn: "idPerimetre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "redevances",
                columns: table => new
                {
                    idRdv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionValorise = table.Column<float>(type: "real", nullable: false),
                    CoutTransport = table.Column<float>(type: "real", nullable: false),
                    typeRdv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateRdv = table.Column<DateOnly>(type: "date", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    perimetreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redevances", x => x.idRdv);
                    table.ForeignKey(
                        name: "FK_redevances_perimetres_perimetreId",
                        column: x => x.perimetreId,
                        principalTable: "perimetres",
                        principalColumn: "idPerimetre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_redevances_produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "produits",
                        principalColumn: "idProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trps",
                columns: table => new
                {
                    idTrp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TauxTrp = table.Column<float>(type: "real", nullable: false),
                    montantTrp = table.Column<float>(type: "real", nullable: false),
                    dateTrp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productionidRdv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trps", x => x.idTrp);
                    table.ForeignKey(
                        name: "FK_trps_redevances_productionidRdv",
                        column: x => x.productionidRdv,
                        principalTable: "redevances",
                        principalColumn: "idRdv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_declarationRedevances_perimetreId",
                table: "declarationRedevances",
                column: "perimetreId");

            migrationBuilder.CreateIndex(
                name: "IX_perimetres_ZoneId",
                table: "perimetres",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_prixBases_ProduitId",
                table: "prixBases",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_prixMns_ProduitId",
                table: "prixMns",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_redevances_perimetreId",
                table: "redevances",
                column: "perimetreId");

            migrationBuilder.CreateIndex(
                name: "IX_redevances_ProduitId",
                table: "redevances",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_tarifTransports_ProduitId",
                table: "tarifTransports",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_trps_productionidRdv",
                table: "trps",
                column: "productionidRdv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "declarationRedevances");

            migrationBuilder.DropTable(
                name: "investissements");

            migrationBuilder.DropTable(
                name: "monnaies");

            migrationBuilder.DropTable(
                name: "prixBases");

            migrationBuilder.DropTable(
                name: "prixMns");

            migrationBuilder.DropTable(
                name: "tarifTransports");

            migrationBuilder.DropTable(
                name: "trps");

            migrationBuilder.DropTable(
                name: "redevances");

            migrationBuilder.DropTable(
                name: "perimetres");

            migrationBuilder.DropTable(
                name: "produits");

            migrationBuilder.DropTable(
                name: "zones");
        }
    }
}
