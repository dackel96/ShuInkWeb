using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class BlogArtistAddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArtistId",
                table: "Happenings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Happenings_ArtistId",
                table: "Happenings",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Happenings_Artists_ArtistId",
                table: "Happenings",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Happenings_Artists_ArtistId",
                table: "Happenings");

            migrationBuilder.DropIndex(
                name: "IX_Happenings_ArtistId",
                table: "Happenings");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Happenings");
        }
    }
}
