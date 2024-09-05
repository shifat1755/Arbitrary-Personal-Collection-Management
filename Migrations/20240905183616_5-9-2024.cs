using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class _592024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SFCompanyName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SFContactName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SFCompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SFContactName",
                table: "Users");
        }
    }
}
