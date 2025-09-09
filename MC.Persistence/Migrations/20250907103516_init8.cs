using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_AddressLine1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "P_AddressLine2",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "P_City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "P_Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "P_District",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "P_PinCode",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "P_State",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "P_AddressLine1",
                table: "Addresses",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "P_AddressLine2",
                table: "Addresses",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "P_City",
                table: "Addresses",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "P_Country",
                table: "Addresses",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "P_District",
                table: "Addresses",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "P_PinCode",
                table: "Addresses",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "P_State",
                table: "Addresses",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
