using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class seedArtists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artists",
                newName: "NickName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Artists",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Artists",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("3779e1cf-9fc5-4a03-9c8a-a2cf6d04ca7b"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("df27f3ce-3a1d-4355-ac45-3f7e0d528955"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("3779e1cf-9fc5-4a03-9c8a-a2cf6d04ca7b"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("df27f3ce-3a1d-4355-ac45-3f7e0d528955"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Artists",
                newName: "Name");
        }
    }
}
