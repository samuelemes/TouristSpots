using Microsoft.EntityFrameworkCore.Migrations;

namespace TouristSpotsData.Migrations
{
    public partial class _01initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    nu_lat = table.Column<double>(nullable: true),
                    nu_lng = table.Column<double>(nullable: true),
                    idCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristSpot_Category_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteTouristSpot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(nullable: false),
                    idTouristSpot = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTouristSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteTouristSpot_TouristSpot_idTouristSpot",
                        column: x => x.idTouristSpot,
                        principalTable: "TouristSpot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteTouristSpot_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpotPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTouristSport = table.Column<int>(nullable: false),
                    idUser = table.Column<int>(nullable: false),
                    ImageTitle = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpotPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristSpotPhoto_TouristSpot_idTouristSport",
                        column: x => x.idTouristSport,
                        principalTable: "TouristSpot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TouristSpotPhoto_Usuario_idUser",
                        column: x => x.idUser,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Park" },
                    { 2, "Museum" },
                    { 3, "Theater" },
                    { 4, "Monument" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTouristSpot_idTouristSpot",
                table: "FavoriteTouristSpot",
                column: "idTouristSpot");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTouristSpot_idUsuario",
                table: "FavoriteTouristSpot",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpot_idCategoria",
                table: "TouristSpot",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotPhoto_idTouristSport",
                table: "TouristSpotPhoto",
                column: "idTouristSport");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotPhoto_idUser",
                table: "TouristSpotPhoto",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteTouristSpot");

            migrationBuilder.DropTable(
                name: "TouristSpotPhoto");

            migrationBuilder.DropTable(
                name: "TouristSpot");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
