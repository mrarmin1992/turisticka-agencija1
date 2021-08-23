using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nezaobilazne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nezaobilazne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veomaznamenite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veomaznamenite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Znamenitosti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Aktivan = table.Column<bool>(type: "INTEGER", nullable: false),
                    Koordinate = table.Column<string>(type: "TEXT", nullable: true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    VeomaznamenitoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NezaobilaznoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Znamenitosti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Znamenitosti_Nezaobilazne_NezaobilaznoId",
                        column: x => x.NezaobilaznoId,
                        principalTable: "Nezaobilazne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Znamenitosti_Veomaznamenite_VeomaznamenitoId",
                        column: x => x.VeomaznamenitoId,
                        principalTable: "Veomaznamenite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Znamenitosti_NezaobilaznoId",
                table: "Znamenitosti",
                column: "NezaobilaznoId");

            migrationBuilder.CreateIndex(
                name: "IX_Znamenitosti_VeomaznamenitoId",
                table: "Znamenitosti",
                column: "VeomaznamenitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Znamenitosti");

            migrationBuilder.DropTable(
                name: "Nezaobilazne");

            migrationBuilder.DropTable(
                name: "Veomaznamenite");
        }
    }
}
