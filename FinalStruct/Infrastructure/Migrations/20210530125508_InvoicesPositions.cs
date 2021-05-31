using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InvoicesPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Invoices_InvoiceId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_InvoiceId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Positions");

            migrationBuilder.CreateTable(
                name: "InvoicePosition",
                columns: table => new
                {
                    InvoicesId = table.Column<int>(type: "int", nullable: false),
                    PositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePosition", x => new { x.InvoicesId, x.PositionsId });
                    table.ForeignKey(
                        name: "FK_InvoicePosition_Invoices_InvoicesId",
                        column: x => x.InvoicesId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePosition_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePosition_PositionsId",
                table: "InvoicePosition",
                column: "PositionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicePosition");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_InvoiceId",
                table: "Positions",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Invoices_InvoiceId",
                table: "Positions",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
