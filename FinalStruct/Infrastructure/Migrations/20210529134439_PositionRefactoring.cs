using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PositionRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionInvoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Invoices",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Invoices");

            migrationBuilder.CreateTable(
                name: "PositionInvoices",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionInvoices", x => new { x.PositionId, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_PositionInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionInvoices_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionInvoices_InvoiceId",
                table: "PositionInvoices",
                column: "InvoiceId");
        }
    }
}
