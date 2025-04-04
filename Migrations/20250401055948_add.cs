using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TieuHaoSanXuat.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumptionReportId",
                table: "MaterialConsumptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsumptionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMaterialsUsed = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionReports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialConsumptions_ConsumptionReportId",
                table: "MaterialConsumptions",
                column: "ConsumptionReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialConsumptions_ConsumptionReports_ConsumptionReportId",
                table: "MaterialConsumptions",
                column: "ConsumptionReportId",
                principalTable: "ConsumptionReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialConsumptions_ConsumptionReports_ConsumptionReportId",
                table: "MaterialConsumptions");

            migrationBuilder.DropTable(
                name: "ConsumptionReports");

            migrationBuilder.DropIndex(
                name: "IX_MaterialConsumptions_ConsumptionReportId",
                table: "MaterialConsumptions");

            migrationBuilder.DropColumn(
                name: "ConsumptionReportId",
                table: "MaterialConsumptions");
        }
    }
}
