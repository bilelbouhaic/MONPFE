using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class migrationtrp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trps_productions_productionidRdv",
                table: "trps");

            migrationBuilder.DropIndex(
                name: "IX_trps_productionidRdv",
                table: "trps");

            migrationBuilder.DropColumn(
                name: "productionidRdv",
                table: "trps");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "dateTrp",
                table: "trps",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dateTrp",
                table: "trps",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "productionidRdv",
                table: "trps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_trps_productionidRdv",
                table: "trps",
                column: "productionidRdv");

            migrationBuilder.AddForeignKey(
                name: "FK_trps_productions_productionidRdv",
                table: "trps",
                column: "productionidRdv",
                principalTable: "productions",
                principalColumn: "idRdv",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
