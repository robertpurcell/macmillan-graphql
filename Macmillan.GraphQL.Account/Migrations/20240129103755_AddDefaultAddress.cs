using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Macmillan.GraphQL.Account.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultAddressId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultAddressId",
                table: "Users",
                column: "DefaultAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_DefaultAddressId",
                table: "Users",
                column: "DefaultAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_DefaultAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DefaultAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DefaultAddressId",
                table: "Users");
        }
    }
}
