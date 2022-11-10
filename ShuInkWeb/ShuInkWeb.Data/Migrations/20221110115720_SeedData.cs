using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuInkWeb.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Address", "ApplicationUserId", "CreatedOn", "DeletedOn", "ImageUrl", "IsDeleted", "ModifiedOn", "Resume" },
                values: new object[,]
                {
                    { new Guid("3992134d-dcb9-4190-a52a-3efb0b048143"), "Велико Търново ул.Зеленка 24", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/shu.jpg", false, null, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." },
                    { new Guid("6f854cfe-0622-41e9-84bd-cb91716ccb30"), "Велико Търново ул.Зеленка 24", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/yngsovage.jpg", false, null, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." },
                    { new Guid("a0e275e8-bb8c-4750-a23b-c7d77778f4f9"), "Велико Търново ул.Зеленка 24", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/shu.jpg", false, null, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." },
                    { new Guid("e20a2da6-0f6b-43fd-acb9-8a1d0b4b5ce5"), "Велико Търново ул.Зеленка 24", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/yngsovage.jpg", false, null, "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SocialMedia", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0755e8ff-7706-49ff-9133-d5aa89d71b36", 0, "4e579f91-ee36-40ca-96b8-52399eeb469b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shu@mail.com", false, "Александър", false, "Спасов", false, null, null, null, null, "AQAAAAEAACcQAAAAEDkql8y7NbscGku7NO1pxslqGdCoxzvkG0hYVsHqaccKGeTFD3ZMseqg5uEkLhVpmA==", "0895792178", false, "05942b61-2f22-433a-b646-472cde52a92f", "https://www.facebook.com/alexandar.spasov2", false, "Shu" },
                    { "7e91ad7d-f555-4044-8d02-3ad7c80c4fab", 0, "4b49b587-4230-4b4a-a3ff-78a572eb13a3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dackel@mail.com", false, "Иван", false, "Илиев", false, null, null, null, null, "AQAAAAEAACcQAAAAEBmfRg4ykWnUpuGdf0geiAaRrggPnqi7wnsG3zA+WXWWPfh8fqSixYX89wpMIfM9CA==", "0895792078", false, "6a51f996-d2af-4447-aaee-43fffc0cf0d3", "https://www.facebook.com/dackel96", false, "dackel" },
                    { "80e0210c-b6b3-401c-a6fa-88d0f10bc7c8", 0, "3752a41f-586f-4a99-8b2f-412321bcc5e3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shu@mail.com", false, "Александър", false, "Спасов", false, null, null, null, null, "AQAAAAEAACcQAAAAEHCU2teg/9rSPj60yWPk12ZPwhbW2W9Nw4thuzbnJGEV7vfOLfnXKTLbmd09YQiGuA==", "0895792178", false, "5aa9af61-47c9-4048-8e8c-6cda1aaaba9b", "https://www.facebook.com/alexandar.spasov2", false, "Shu" },
                    { "8526d1f3-2a91-46f7-8926-857d80bd620a", 0, "7d7d03d2-1cb4-4c50-8798-5d5e25d485da", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yngsovage@mail.com", false, "Петър", false, "Ангелов", false, null, null, null, null, "AQAAAAEAACcQAAAAEACB2RqFkUJsJspzl3rWXSbjtVVbuFTVPBwSESXxi1Yro0H/3jyTFEpU5Co3MuizOw==", "0895792378", false, "3f4d42cf-9184-46f5-a74c-096ff739e9e2", "https://www.facebook.com/petar.angelov.92", false, "yngsovage" },
                    { "a4f7e70c-827e-4860-9182-8cb42d81cdde", 0, "9dae6b55-1f5f-4541-98d7-aca2d5289b80", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "yngsovage@mail.com", false, "Петър", false, "Ангелов", false, null, null, null, null, "AQAAAAEAACcQAAAAELd2Cqu/X3NdhjSahBv+vMg6KN4crEnQGhDCCujoruuCuGhw9L+t9+dfd0MFYKIn/g==", "0895792378", false, "ebb6a760-2216-4ffe-8dd8-cd0a52662419", "https://www.facebook.com/petar.angelov.92", false, "yngsovage" },
                    { "ba54e0af-eb33-4611-af8f-8d65718c5828", 0, "9b75c7db-4185-472a-a429-0ba780b796d2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "dackel@mail.com", false, "Иван", false, "Илиев", false, null, null, null, null, "AQAAAAEAACcQAAAAENDea5nx56vn2Bd+xEsJCaiVYrci4X+x9P6oT+TNKpgOrkT4jdxAZv+BAYbQGaOOzA==", "0895792078", false, "52fbb459-c357-4458-b2dc-815a58a55f95", "https://www.facebook.com/dackel96", false, "dackel" }
                });

            migrationBuilder.InsertData(
                table: "Tattos",
                columns: new[] { "Id", "ArtistId", "CreatedOn", "DeletedOn", "ImageUrl", "IsDeleted", "ModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("0609a214-1880-4f3c-aa9b-9b72f79fb3fd"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/1.jpg", false, null, "rand2" },
                    { new Guid("0667644c-2b03-4db9-827f-3fab01794dfd"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/5.jpg", false, null, "rand3" },
                    { new Guid("40e99ed0-ca53-43dc-b65f-03e753e54c61"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/3.jpg", false, null, "rand1" },
                    { new Guid("6e997d69-56db-4853-b796-66c49c8d4dce"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/15.jpg", false, null, "rand1" },
                    { new Guid("76de859e-6a42-4e88-a762-1e7385305185"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/4.jpg", false, null, "rand2" },
                    { new Guid("7c4f0549-ec09-4ae5-b922-a2eb434579be"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/2.jpg", false, null, "rand3" },
                    { new Guid("8c6d8855-c024-4cb8-8707-ba04c7f1be61"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/15.jpg", false, null, "rand1" },
                    { new Guid("94777d1d-18c6-48d0-811a-e05324589381"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/4.jpg", false, null, "rand2" },
                    { new Guid("a03604b8-e589-44c3-8276-06e69074f795"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/1.jpg", false, null, "rand2" },
                    { new Guid("ca523d73-32a3-4231-b5a8-23162c00f7e4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/2.jpg", false, null, "rand3" },
                    { new Guid("cbf222aa-d3d4-46d0-b741-3451d7edb5d9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/3.jpg", false, null, "rand1" },
                    { new Guid("cfb4b95c-2520-4480-9e12-a3fff9e53307"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://raw.githubusercontent.com/dackel96/ShuInkWeb/main/Photos/5.jpg", false, null, "rand3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("3992134d-dcb9-4190-a52a-3efb0b048143"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("6f854cfe-0622-41e9-84bd-cb91716ccb30"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("a0e275e8-bb8c-4750-a23b-c7d77778f4f9"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("e20a2da6-0f6b-43fd-acb9-8a1d0b4b5ce5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0755e8ff-7706-49ff-9133-d5aa89d71b36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e91ad7d-f555-4044-8d02-3ad7c80c4fab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80e0210c-b6b3-401c-a6fa-88d0f10bc7c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8526d1f3-2a91-46f7-8926-857d80bd620a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4f7e70c-827e-4860-9182-8cb42d81cdde");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba54e0af-eb33-4611-af8f-8d65718c5828");

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("0609a214-1880-4f3c-aa9b-9b72f79fb3fd"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("0667644c-2b03-4db9-827f-3fab01794dfd"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("40e99ed0-ca53-43dc-b65f-03e753e54c61"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("6e997d69-56db-4853-b796-66c49c8d4dce"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("76de859e-6a42-4e88-a762-1e7385305185"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("7c4f0549-ec09-4ae5-b922-a2eb434579be"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("8c6d8855-c024-4cb8-8707-ba04c7f1be61"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("94777d1d-18c6-48d0-811a-e05324589381"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("a03604b8-e589-44c3-8276-06e69074f795"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("ca523d73-32a3-4231-b5a8-23162c00f7e4"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("cbf222aa-d3d4-46d0-b741-3451d7edb5d9"));

            migrationBuilder.DeleteData(
                table: "Tattos",
                keyColumn: "Id",
                keyValue: new Guid("cfb4b95c-2520-4480-9e12-a3fff9e53307"));
        }
    }
}
