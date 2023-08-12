using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressType",
                table: "Addresses",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "AddressDetails",
                table: "Addresses",
                newName: "Details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Addresses",
                newName: "AddressType");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Addresses",
                newName: "AddressDetails");
        }
    }
}
