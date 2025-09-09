using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPermanentAddressSame",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "C_State",
                table: "Addresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "C_PinCode",
                table: "Addresses",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "C_District",
                table: "Addresses",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "C_Country",
                table: "Addresses",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "C_City",
                table: "Addresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "C_AddressLine2",
                table: "Addresses",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "C_AddressLine1",
                table: "Addresses",
                newName: "AddressLine1");

            migrationBuilder.AddColumn<string>(
                name: "AddressType",
                table: "Addresses",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressType",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "C_State");

            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "Addresses",
                newName: "C_PinCode");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Addresses",
                newName: "C_District");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "C_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Addresses",
                newName: "C_City");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Addresses",
                newName: "C_AddressLine2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Addresses",
                newName: "C_AddressLine1");

            migrationBuilder.AddColumn<bool>(
                name: "IsPermanentAddressSame",
                table: "Addresses",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
