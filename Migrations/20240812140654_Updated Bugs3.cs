using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBugs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomMultileineText1",
                table: "Collections",
                newName: "CustomMultilineText1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomMultilineText1",
                table: "Collections",
                newName: "CustomMultileineText1");
        }
    }
}
