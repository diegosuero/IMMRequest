using Microsoft.EntityFrameworkCore.Migrations;

namespace IMMRequest.DataAccess.Migrations
{
    public partial class AgregarValor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "valor",
                table: "CampoAdicional",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Valor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(nullable: true),
                    CampoAicionalTextoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Valor_CampoAdicional_CampoAicionalTextoId",
                        column: x => x.CampoAicionalTextoId,
                        principalTable: "CampoAdicional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valor_CampoAicionalTextoId",
                table: "Valor",
                column: "CampoAicionalTextoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valor");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "CampoAdicional");
        }
    }
}
