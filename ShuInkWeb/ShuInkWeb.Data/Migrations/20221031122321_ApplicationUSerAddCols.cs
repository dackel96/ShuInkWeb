using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class ApplicationUSerAddCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("3779e1cf-9fc5-4a03-9c8a-a2cf6d04ca7b"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("df27f3ce-3a1d-4355-ac45-3f7e0d528955"));

            migrationBuilder.AlterColumn<string>(
                name: "SocialMedia",
                table: "AspNetUsers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("0e164951-12fa-4c85-8a49-fcafd74e7634"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("aac23ca4-7532-4884-9750-acb6676f88b2"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("0e164951-12fa-4c85-8a49-fcafd74e7634"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("aac23ca4-7532-4884-9750-acb6676f88b2"));

            migrationBuilder.AlterColumn<string>(
                name: "SocialMedia",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("3779e1cf-9fc5-4a03-9c8a-a2cf6d04ca7b"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("df27f3ce-3a1d-4355-ac45-3f7e0d528955"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });
        }
    }
}
