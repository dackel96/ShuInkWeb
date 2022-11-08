using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class RemoveUSerHappeningRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Happenings_AspNetUsers_UserId",
                table: "Happenings");

            migrationBuilder.DropIndex(
                name: "IX_Happenings_UserId",
                table: "Happenings");

            //migrationBuilder.DeleteData(
            //    table: "Artists",
            //    keyColumn: "Id",
            //    keyValue: new Guid("78d10525-09e7-4676-8799-9b07b82dac5b"));

            //migrationBuilder.DeleteData(
            //    table: "Artists",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a202db1f-6466-4775-8a93-38045d632134"));

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "413f4305-47d0-4648-8600-3ac5b7f0f2b9");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "41f39b68-84f6-48b5-9569-12b588693c29");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "4a798927-6e41-4042-9a54-722f7461357c");

            //migrationBuilder.DeleteData(
            //    table: "Tattos",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1d759a45-8235-44f6-8eea-fbb3da9db890"));

            //migrationBuilder.DeleteData(
            //    table: "Tattos",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3b617ee1-c60a-43e4-9316-1309d7c40f08"));

            //migrationBuilder.DeleteData(
            //    table: "Tattos",
            //    keyColumn: "Id",
            //    keyValue: new Guid("523636ea-cb1e-46fe-affa-d5ebc239543f"));

            //migrationBuilder.DeleteData(
            //    table: "Tattos",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7c49b168-4aa0-4f04-ad74-1ddb9ead7546"));

            //migrationBuilder.DeleteData(
            //    table: "Tattos",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b5e44661-a043-413c-a49d-1c6c95df5c9a"));

            //migrationBuilder.DeleteData(
            //    table: "Tattos",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bc57caef-4b4f-4b0a-b080-cc34bf3e0bcd"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Happenings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Happenings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Address", "ApplicationUserId", "ImageUrl", "Resume" },
                values: new object[,]
                {
                    { new Guid("78d10525-09e7-4676-8799-9b07b82dac5b"), "Велико Търново ул.Зеленка 24", null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/shu.jpg", "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." },
                    { new Guid("a202db1f-6466-4775-8a93-38045d632134"), "Велико Търново ул.Зеленка 24", null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/yngsovage.jpg", "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SocialMedia", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "413f4305-47d0-4648-8600-3ac5b7f0f2b9", 0, "fe15fbf8-ce25-423d-97c2-c1d3f9f802be", "shu@mail.com", false, "Александър", "Спасов", false, null, null, null, "AQAAAAEAACcQAAAAEC3vebBjtyDkTbkbQC5iVsqc9MXOdJJuUg40UzRKt/1j3w+n0hPMsLf4SpLKKHE5IA==", "0895792178", false, "d672b2fe-5f92-4dc7-aa35-b347182727cb", "https://www.facebook.com/alexandar.spasov2", false, "Shu" },
                    { "41f39b68-84f6-48b5-9569-12b588693c29", 0, "ae0c1262-f981-4c07-beab-55396165d056", "yngsovage@mail.com", false, "Петър", "Ангелов", false, null, null, null, "AQAAAAEAACcQAAAAECI+pOa+itVv9mmGqtFcJb8mbLnfXSD9mOh0LJ7Bc1dGm+Ao2oZqhmdob2My5RV6lw==", "0895792378", false, "e3a35b32-0a11-489a-a9ff-bd8f8dda7c3d", "https://www.facebook.com/petar.angelov.92", false, "yngsovage" },
                    { "4a798927-6e41-4042-9a54-722f7461357c", 0, "0967191d-0e05-4661-80db-417bda165338", "dackel@mail.com", false, "Иван", "Илиев", false, null, null, null, "AQAAAAEAACcQAAAAEIMNaqvuidACVRaulrFClvjxNOlQKoJsR53zdpFoEvofH6wjvVx5O9APq0GOLpEEtA==", "0895792078", false, "336315a8-30e1-4b65-893c-4d639ec228b2", "https://www.facebook.com/dackel96", false, "dackel" }
                });

            migrationBuilder.InsertData(
                table: "Tattos",
                columns: new[] { "Id", "ArtistId", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("1d759a45-8235-44f6-8eea-fbb3da9db890"), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/1.jpg", "rand2" },
                    { new Guid("3b617ee1-c60a-43e4-9316-1309d7c40f08"), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/4.jpg", "rand2" },
                    { new Guid("523636ea-cb1e-46fe-affa-d5ebc239543f"), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/3.jpg", "rand1" },
                    { new Guid("7c49b168-4aa0-4f04-ad74-1ddb9ead7546"), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/15.jpg", "rand1" },
                    { new Guid("b5e44661-a043-413c-a49d-1c6c95df5c9a"), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/2.jpg", "rand3" },
                    { new Guid("bc57caef-4b4f-4b0a-b080-cc34bf3e0bcd"), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/5.jpg", "rand3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Happenings_UserId",
                table: "Happenings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Happenings_AspNetUsers_UserId",
                table: "Happenings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
