using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class MerchandiseTablesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("0e164951-12fa-4c85-8a49-fcafd74e7634"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("aac23ca4-7532-4884-9750-acb6676f88b2"));

            migrationBuilder.CreateTable(
                name: "MerchandiseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchandiseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchandises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsInStock = table.Column<bool>(type: "bit", nullable: false),
                    MerchandiseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandises_MerchandiseTypes_MerchandiseTypeId",
                        column: x => x.MerchandiseTypeId,
                        principalTable: "MerchandiseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("67a0fc3f-47b7-4686-9082-350feb9f9905"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("afda97a4-8e2d-48ed-baa2-b83a60e88487"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.CreateIndex(
                name: "IX_Merchandises_MerchandiseTypeId",
                table: "Merchandises",
                column: "MerchandiseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchandises");

            migrationBuilder.DropTable(
                name: "MerchandiseTypes");

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("67a0fc3f-47b7-4686-9082-350feb9f9905"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("afda97a4-8e2d-48ed-baa2-b83a60e88487"));

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("0e164951-12fa-4c85-8a49-fcafd74e7634"), true, "Peter", "Angelov", "Svg", "Lorem Ipsum", "10:00 - 18:00" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Availability", "FirstName", "LastName", "NickName", "Resume", "WorkTime" },
                values: new object[] { new Guid("aac23ca4-7532-4884-9750-acb6676f88b2"), true, "Alexander", "Spasov", "Shu", "Lorem Ipsum", "10:00 - 18:00" });
        }
    }
}
