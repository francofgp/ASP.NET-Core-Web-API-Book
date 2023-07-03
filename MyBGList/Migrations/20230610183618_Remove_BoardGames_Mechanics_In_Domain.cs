using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBGList.Migrations
{
    /// <inheritdoc />
    public partial class Remove_BoardGames_Mechanics_In_Domain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_Mechanics_Domains_DomainId",
                table: "BoardGames_Mechanics");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_Mechanics_DomainId",
                table: "BoardGames_Mechanics");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "BoardGames_Mechanics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomainId",
                table: "BoardGames_Mechanics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_Mechanics_DomainId",
                table: "BoardGames_Mechanics",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_Mechanics_Domains_DomainId",
                table: "BoardGames_Mechanics",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "Id");
        }
    }
}
