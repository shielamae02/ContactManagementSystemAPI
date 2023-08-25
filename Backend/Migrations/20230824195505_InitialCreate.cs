using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    ContactNumber1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NumberLabel1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactNumber2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberLabel2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactNumber3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberLabel3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressDetails1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLabel1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressDetails2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLabel2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AddressDetails3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLabel3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
