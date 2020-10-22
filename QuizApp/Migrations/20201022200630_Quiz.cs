using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Migrations
{
    public partial class Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quiz = table.Column<string>(nullable: false),
                    Quest = table.Column<string>(nullable: false),
                    Answ0 = table.Column<string>(nullable: false),
                    Answ1 = table.Column<string>(nullable: false),
                    Answ2 = table.Column<string>(nullable: true),
                    Answ3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qestion");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
