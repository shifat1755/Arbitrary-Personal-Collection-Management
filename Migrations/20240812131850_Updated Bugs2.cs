using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBugs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomStringFieldCount",
                table: "Collections",
                newName: "CustomStringCount");

            migrationBuilder.RenameColumn(
                name: "CustomMultilineTextFieldCount",
                table: "Collections",
                newName: "CustomMultilineTextCount");

            migrationBuilder.RenameColumn(
                name: "CustomIntFieldCount",
                table: "Collections",
                newName: "CustomIntCount");

            migrationBuilder.RenameColumn(
                name: "CustomDateFieldCount",
                table: "Collections",
                newName: "CustomDateCount");

            migrationBuilder.RenameColumn(
                name: "CustomDateField3Val",
                table: "Collections",
                newName: "CustomDate3Val");

            migrationBuilder.RenameColumn(
                name: "CustomDateField2Val",
                table: "Collections",
                newName: "CustomDate2Val");

            migrationBuilder.RenameColumn(
                name: "CustomDateField2",
                table: "Collections",
                newName: "CustomDate3");

            migrationBuilder.RenameColumn(
                name: "CustomDateField1Val",
                table: "Collections",
                newName: "CustomDate1Val");

            migrationBuilder.RenameColumn(
                name: "CustomDateField1",
                table: "Collections",
                newName: "CustomDate2");

            migrationBuilder.RenameColumn(
                name: "CustomDataField3",
                table: "Collections",
                newName: "CustomDate1");

            migrationBuilder.RenameColumn(
                name: "CustomBoolFieldCount",
                table: "Collections",
                newName: "CustomBoolCount");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField3Val",
                table: "Collections",
                newName: "CustomBool3Val");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField3",
                table: "Collections",
                newName: "CustomBool3");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField2Val",
                table: "Collections",
                newName: "CustomBool2Val");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField2",
                table: "Collections",
                newName: "CustomBool2");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField1Val",
                table: "Collections",
                newName: "CustomBool1Val");

            migrationBuilder.RenameColumn(
                name: "CustomBoolField1",
                table: "Collections",
                newName: "CustomBool1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomStringCount",
                table: "Collections",
                newName: "CustomStringFieldCount");

            migrationBuilder.RenameColumn(
                name: "CustomMultilineTextCount",
                table: "Collections",
                newName: "CustomMultilineTextFieldCount");

            migrationBuilder.RenameColumn(
                name: "CustomIntCount",
                table: "Collections",
                newName: "CustomIntFieldCount");

            migrationBuilder.RenameColumn(
                name: "CustomDateCount",
                table: "Collections",
                newName: "CustomDateFieldCount");

            migrationBuilder.RenameColumn(
                name: "CustomDate3Val",
                table: "Collections",
                newName: "CustomDateField3Val");

            migrationBuilder.RenameColumn(
                name: "CustomDate3",
                table: "Collections",
                newName: "CustomDateField2");

            migrationBuilder.RenameColumn(
                name: "CustomDate2Val",
                table: "Collections",
                newName: "CustomDateField2Val");

            migrationBuilder.RenameColumn(
                name: "CustomDate2",
                table: "Collections",
                newName: "CustomDateField1");

            migrationBuilder.RenameColumn(
                name: "CustomDate1Val",
                table: "Collections",
                newName: "CustomDateField1Val");

            migrationBuilder.RenameColumn(
                name: "CustomDate1",
                table: "Collections",
                newName: "CustomDataField3");

            migrationBuilder.RenameColumn(
                name: "CustomBoolCount",
                table: "Collections",
                newName: "CustomBoolFieldCount");

            migrationBuilder.RenameColumn(
                name: "CustomBool3Val",
                table: "Collections",
                newName: "CustomBoolField3Val");

            migrationBuilder.RenameColumn(
                name: "CustomBool3",
                table: "Collections",
                newName: "CustomBoolField3");

            migrationBuilder.RenameColumn(
                name: "CustomBool2Val",
                table: "Collections",
                newName: "CustomBoolField2Val");

            migrationBuilder.RenameColumn(
                name: "CustomBool2",
                table: "Collections",
                newName: "CustomBoolField2");

            migrationBuilder.RenameColumn(
                name: "CustomBool1Val",
                table: "Collections",
                newName: "CustomBoolField1Val");

            migrationBuilder.RenameColumn(
                name: "CustomBool1",
                table: "Collections",
                newName: "CustomBoolField1");
        }
    }
}
