using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "CustomFIeldValues",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFIeldValues_ItemId",
                table: "CustomFIeldValues",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFIeldValues_Items_ItemId",
                table: "CustomFIeldValues",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFIeldValues_Items_ItemId",
                table: "CustomFIeldValues");

            migrationBuilder.DropIndex(
                name: "IX_CustomFIeldValues_ItemId",
                table: "CustomFIeldValues");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "CustomFIeldValues");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
