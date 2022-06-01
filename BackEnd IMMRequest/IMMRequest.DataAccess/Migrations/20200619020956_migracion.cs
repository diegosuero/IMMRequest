using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMMRequest.DataAccess.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor",
                table: "CampoAdicional");

            migrationBuilder.AddColumn<int>(
                name: "CampoAicionalTextoId1",
                table: "Valor",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaIngreso",
                table: "Solicitudes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Valor_CampoAicionalTextoId1",
                table: "Valor",
                column: "CampoAicionalTextoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Valor_CampoAdicional_CampoAicionalTextoId1",
                table: "Valor",
                column: "CampoAicionalTextoId1",
                principalTable: "CampoAdicional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Valor_CampoAdicional_CampoAicionalTextoId1",
                table: "Valor");

            migrationBuilder.DropIndex(
                name: "IX_Valor_CampoAicionalTextoId1",
                table: "Valor");

            migrationBuilder.DropColumn(
                name: "CampoAicionalTextoId1",
                table: "Valor");

            migrationBuilder.DropColumn(
                name: "fechaIngreso",
                table: "Solicitudes");

            migrationBuilder.AddColumn<string>(
                name: "valor",
                table: "CampoAdicional",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
