using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnyFieldsTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Banks");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "UserAccounts",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Banks",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
