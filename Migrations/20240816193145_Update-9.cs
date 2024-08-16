using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class Update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomField_Collections_CollectionId",
                table: "CustomField");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_CustomField_CustomFieldId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CustomFieldId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomField",
                table: "CustomField");

            migrationBuilder.DropColumn(
                name: "CustomFieldId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "CustomField");

            migrationBuilder.RenameTable(
                name: "CustomField",
                newName: "CustomFields");

            migrationBuilder.RenameIndex(
                name: "IX_CustomField_CollectionId",
                table: "CustomFields",
                newName: "IX_CustomFields_CollectionId");

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomFields",
                table: "CustomFields",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomFIeldValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFIeldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFIeldValues_CustomFields_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFIeldValues_CustomFieldId",
                table: "CustomFIeldValues",
                column: "CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Collections_CollectionId",
                table: "CustomFields",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Collections_CollectionId",
                table: "CustomFields");

            migrationBuilder.DropTable(
                name: "CustomFIeldValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomFields",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "ItemCount",
                table: "Collections");

            migrationBuilder.RenameTable(
                name: "CustomFields",
                newName: "CustomField");

            migrationBuilder.RenameIndex(
                name: "IX_CustomFields_CollectionId",
                table: "CustomField",
                newName: "IX_CustomField_CollectionId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomFieldId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "CustomField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomField",
                table: "CustomField",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomFieldId",
                table: "Items",
                column: "CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomField_Collections_CollectionId",
                table: "CustomField",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CustomField_CustomFieldId",
                table: "Items",
                column: "CustomFieldId",
                principalTable: "CustomField",
                principalColumn: "Id");
        }
    }
}
