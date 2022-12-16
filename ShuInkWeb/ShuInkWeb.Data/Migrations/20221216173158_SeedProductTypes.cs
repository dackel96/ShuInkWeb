using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class SeedProductTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MerchandiseTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[] { new Guid("15d17ef0-a550-4760-974c-60cbe9abb8d6"), new DateTime(2022, 12, 16, 19, 31, 58, 498, DateTimeKind.Local).AddTicks(8902), null, false, null, "Cloth" });

            migrationBuilder.InsertData(
                table: "MerchandiseTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[] { new Guid("31f284d2-7c3b-4eae-98a1-3c23640802f6"), new DateTime(2022, 12, 16, 19, 31, 58, 498, DateTimeKind.Local).AddTicks(8979), null, false, null, "AfterCare" });

            migrationBuilder.InsertData(
                table: "MerchandiseTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[] { new Guid("ad22cb0c-8531-4d04-8685-a5092e62a2ba"), new DateTime(2022, 12, 16, 19, 31, 58, 498, DateTimeKind.Local).AddTicks(8986), null, false, null, "Accessori" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MerchandiseTypes",
                keyColumn: "Id",
                keyValue: new Guid("15d17ef0-a550-4760-974c-60cbe9abb8d6"));

            migrationBuilder.DeleteData(
                table: "MerchandiseTypes",
                keyColumn: "Id",
                keyValue: new Guid("31f284d2-7c3b-4eae-98a1-3c23640802f6"));

            migrationBuilder.DeleteData(
                table: "MerchandiseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ad22cb0c-8531-4d04-8685-a5092e62a2ba"));
        }
    }
}
