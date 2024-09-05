using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class db392024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "Summury",
                table: "Ticket",
                newName: "Summary");

            migrationBuilder.AddColumn<string>(
                name: "JiraAccountId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollectionName",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JiraAccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CollectionName",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Ticket",
                newName: "Summury");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
