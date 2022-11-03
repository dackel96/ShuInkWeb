using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class MerchandiseImageFieldAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("67a0fc3f-47b7-4686-9082-350feb9f9905"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("afda97a4-8e2d-48ed-baa2-b83a60e88487"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Merchandises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("7c33c5bc-7509-44bf-846f-9c2bd04105ce"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("7fb38d53-f676-4023-a31b-fac15c3659c5"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("7c33c5bc-7509-44bf-846f-9c2bd04105ce"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("7fb38d53-f676-4023-a31b-fac15c3659c5"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Merchandises");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("67a0fc3f-47b7-4686-9082-350feb9f9905"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("afda97a4-8e2d-48ed-baa2-b83a60e88487"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });
        }
    }
}
