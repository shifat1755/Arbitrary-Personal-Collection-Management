using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBugs4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomBool1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomBool1Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomBool2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomBool2Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomBool3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomBool3Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomBoolCount",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDate1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDate1Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDate2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDate2Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDate3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDate3Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomDateCount",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomInt1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomInt1Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomInt2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomInt2Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomInt3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomInt3Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomIntCount",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineText1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineText1Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineText2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineText2Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineText3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineText3Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomMultilineTextCount",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomString1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomString1Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomString2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomString2Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomString3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomString3Val",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CustomStringCount",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "CustomFieldId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomField_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomFieldId",
                table: "Items",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomField_CollectionId",
                table: "CustomField",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CustomField_CustomFieldId",
                table: "Items",
                column: "CustomFieldId",
                principalTable: "CustomField",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CustomField_CustomFieldId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "CustomField");

            migrationBuilder.DropIndex(
                name: "IX_Items_CustomFieldId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomFieldId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "CustomBool1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool1Val",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool2Val",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomBool3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomBool3Val",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CustomBoolCount",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomDate1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CustomDate1Val",
                table: "Collections",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomDate2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CustomDate2Val",
                table: "Collections",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomDate3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CustomDate3Val",
                table: "Collections",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomDateCount",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInt1Val",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInt2Val",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomInt3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomInt3Val",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomIntCount",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultilineText1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultilineText1Val",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultilineText2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultilineText2Val",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultilineText3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomMultilineText3Val",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomMultilineTextCount",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomString1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString1Val",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString2Val",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomString3Val",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomStringCount",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
