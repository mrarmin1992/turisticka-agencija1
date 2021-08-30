using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
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
                    VeomaznamenitoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    ZnamenitostId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Znamenitosti_ZnamenitostId",
                        column: x => x.ZnamenitostId,
                        principalTable: "Znamenitosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ZnamenitostId",
                table: "Photo",
                column: "ZnamenitostId");

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
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Znamenitosti");

            migrationBuilder.DropTable(
                name: "Nezaobilazne");

            migrationBuilder.DropTable(
                name: "Veomaznamenite");
        }
    }
}
