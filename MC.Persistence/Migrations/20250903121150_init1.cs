using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "UserProfiles",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("83b6730a-c27c-4898-a7ca-29ad3b59213a"),
                column: "ProfilePictureUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("ed8e68c4-4df4-4989-9155-fed3052d8d25"),
                column: "ProfilePictureUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "ProfilePictureUrl",
                keyValue: null,
                column: "ProfilePictureUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePictureUrl",
                table: "UserProfiles",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("83b6730a-c27c-4898-a7ca-29ad3b59213a"),
                column: "ProfilePictureUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: new Guid("ed8e68c4-4df4-4989-9155-fed3052d8d25"),
                column: "ProfilePictureUrl",
                value: "");
        }
    }
}
