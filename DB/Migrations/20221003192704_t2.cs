using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class t2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_Tipos_Type2",
                table: "Pokemones");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Pokemones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Tipo2",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTipos = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo2", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_name",
                table: "Pokemones",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tipo2_NameTipos",
                table: "Tipo2",
                column: "NameTipos",
                unique: true,
                filter: "[NameTipos] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_Tipo2_Type2",
                table: "Pokemones",
                column: "Type2",
                principalTable: "Tipo2",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_Tipo2_Type2",
                table: "Pokemones");

            migrationBuilder.DropTable(
                name: "Tipo2");

            migrationBuilder.DropIndex(
                name: "IX_Pokemones_name",
                table: "Pokemones");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Pokemones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_Tipos_Type2",
                table: "Pokemones",
                column: "Type2",
                principalTable: "Tipos",
                principalColumn: "id");
        }
    }
}
