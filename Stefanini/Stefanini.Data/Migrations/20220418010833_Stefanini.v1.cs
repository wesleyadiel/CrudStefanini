using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stefanini.Data.Migrations
{
    public partial class Stefaniniv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Id_Cidade",
                table: "Pessoas",
                column: "Id_Cidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Cidades_Id_Cidade",
                table: "Pessoas",
                column: "Id_Cidade",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Cidades_Id_Cidade",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_Id_Cidade",
                table: "Pessoas");
        }
    }
}
