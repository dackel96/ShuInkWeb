using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tattos_Artists_ArtistId",
                table: "Tattos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tattos",
                table: "Tattos");

            migrationBuilder.RenameTable(
                name: "Tattos",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Tattos_IsDeleted",
                table: "Images",
                newName: "IX_Images_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Tattos_ArtistId",
                table: "Images",
                newName: "IX_Images_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Artists_ArtistId",
                table: "Images",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Artists_ArtistId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Tattos");

            migrationBuilder.RenameIndex(
                name: "IX_Images_IsDeleted",
                table: "Tattos",
                newName: "IX_Tattos_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ArtistId",
                table: "Tattos",
                newName: "IX_Tattos_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tattos",
                table: "Tattos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tattos_Artists_ArtistId",
                table: "Tattos",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
