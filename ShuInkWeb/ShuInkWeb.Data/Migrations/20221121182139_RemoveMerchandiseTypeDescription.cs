using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class RemoveMerchandiseTypeDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MerchandiseTypes");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MerchandiseTypes",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MerchandiseTypes",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MerchandiseTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
