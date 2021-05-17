using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class EliminateInvTPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceThirdParties");

            migrationBuilder.AddColumn<int>(
                name: "ThirdPartyPersonId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ThirdPartyPersonId",
                table: "Invoices",
                column: "ThirdPartyPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ThirdParties_ThirdPartyPersonId",
                table: "Invoices",
                column: "ThirdPartyPersonId",
                principalTable: "ThirdParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ThirdParties_ThirdPartyPersonId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ThirdPartyPersonId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ThirdPartyPersonId",
                table: "Invoices");

            migrationBuilder.CreateTable(
                name: "InvoiceThirdParties",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ThirdPartyPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceThirdParties", x => new { x.InvoiceId, x.ThirdPartyPersonId });
                    table.ForeignKey(
                        name: "FK_InvoiceThirdParties_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceThirdParties_ThirdParties_ThirdPartyPersonId",
                        column: x => x.ThirdPartyPersonId,
                        principalTable: "ThirdParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceThirdParties_ThirdPartyPersonId",
                table: "InvoiceThirdParties",
                column: "ThirdPartyPersonId");
        }
    }
}
