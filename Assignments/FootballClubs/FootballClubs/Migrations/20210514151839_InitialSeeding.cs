using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballClubs.Migrations
{
    public partial class InitialSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundationYear = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Country", "FoundationYear", "Name" },
                values: new object[,]
                {
                    { 1, "England", 1992, "Premier League" },
                    { 2, "Spain", 1983, "La Liga" },
                    { 3, "Italy", 1946, "Seria A" },
                    { 4, "Gernamy", 2000, "Bundesliga" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "LeagueId", "MarketValue", "Name", "NickName" },
                values: new object[,]
                {
                    { 1, 1, 1010000000.0, "FC Liverpool", "The Reds" },
                    { 3, 1, 549000000.0, "FC Arsenal", "The Gunners" },
                    { 4, 1, 1030000000.0, "FC Manchester City", "The Citizens" },
                    { 2, 2, 823000000.0, "FC Barcelona", "Blougrana" },
                    { 5, 2, 270000000.0, "FC Valecia", "The Bats" },
                    { 6, 2, 745000000.0, "Real Madrid", "Blancos" },
                    { 7, 3, 678000000.0, "FC Juventus", "The Old Lady" },
                    { 8, 3, 618000000.0, "FC Internazionale Milano", "Blanco-Nerri" },
                    { 9, 4, 581000000.0, "FC Borrusia Dortmund", "BVB" },
                    { 10, 4, 841000000.0, "FC Bayern Munich", "The Bavarians" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LeagueId",
                table: "Clubs",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
