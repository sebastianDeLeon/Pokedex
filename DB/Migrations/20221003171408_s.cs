using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRegion = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTipos = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type1 = table.Column<int>(type: "int", nullable: false),
                    Type2 = table.Column<int>(type: "int", nullable: true),
                    RegionPokemon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pokemones_Regiones_RegionPokemon",
                        column: x => x.RegionPokemon,
                        principalTable: "Regiones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_Type1",
                        column: x => x.Type1,
                        principalTable: "Tipos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_Type2",
                        column: x => x.Type2,
                        principalTable: "Tipos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_RegionPokemon",
                table: "Pokemones",
                column: "RegionPokemon");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_Type1",
                table: "Pokemones",
                column: "Type1");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_Type2",
                table: "Pokemones",
                column: "Type2");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_NameRegion",
                table: "Regiones",
                column: "NameRegion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_NameTipos",
                table: "Tipos",
                column: "NameTipos",
                unique: true,
                filter: "[NameTipos] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemones");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
