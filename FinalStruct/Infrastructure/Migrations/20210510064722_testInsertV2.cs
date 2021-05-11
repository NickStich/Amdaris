using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class testInsertV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionInvoice_Invoices_InvoiceId",
                table: "PositionInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionInvoice_Positions_PositionId",
                table: "PositionInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionInvoice",
                table: "PositionInvoice");

            migrationBuilder.RenameTable(
                name: "PositionInvoice",
                newName: "PositionInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_PositionInvoice_InvoiceId",
                table: "PositionInvoices",
                newName: "IX_PositionInvoices_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionInvoices",
                table: "PositionInvoices",
                columns: new[] { "PositionId", "InvoiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInvoices_Invoices_InvoiceId",
                table: "PositionInvoices",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInvoices_Positions_PositionId",
                table: "PositionInvoices",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionInvoices_Invoices_InvoiceId",
                table: "PositionInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionInvoices_Positions_PositionId",
                table: "PositionInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionInvoices",
                table: "PositionInvoices");

            migrationBuilder.RenameTable(
                name: "PositionInvoices",
                newName: "PositionInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_PositionInvoices_InvoiceId",
                table: "PositionInvoice",
                newName: "IX_PositionInvoice_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PositionInvoice",
                table: "PositionInvoice",
                columns: new[] { "PositionId", "InvoiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInvoice_Invoices_InvoiceId",
                table: "PositionInvoice",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionInvoice_Positions_PositionId",
                table: "PositionInvoice",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
