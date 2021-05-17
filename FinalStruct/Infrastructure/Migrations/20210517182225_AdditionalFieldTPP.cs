using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AdditionalFieldTPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ThirdParties");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "ThirdParties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "ThirdParties");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ThirdParties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
