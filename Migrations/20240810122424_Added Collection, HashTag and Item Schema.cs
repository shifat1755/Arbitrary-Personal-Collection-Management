using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class AddedCollectionHashTagandItemSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomInt1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomInt1Val = table.Column<int>(type: "int", nullable: true),
                    CustomInt2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomInt2Val = table.Column<int>(type: "int", nullable: true),
                    CustomInt3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomInt3Val = table.Column<int>(type: "int", nullable: true),
                    CustomIntFieldCount = table.Column<int>(type: "int", nullable: false),
                    CustomString1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString1Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString2Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString3Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomStringFieldCount = table.Column<int>(type: "int", nullable: false),
                    CustomMultileineText1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText1Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText2Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText3Val = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineTextFieldCount = table.Column<int>(type: "int", nullable: false),
                    CustomDateField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomDateField1Val = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomDateField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomDateField2Val = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomDataField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomDateField3Val = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomDateFieldCount = table.Column<int>(type: "int", nullable: false),
                    CustomBoolField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomBoolField1Val = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomBoolField2Val = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomBoolField3Val = table.Column<bool>(type: "bit", nullable: false),
                    CustomBoolFieldCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hashTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hashTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HashTagItem",
                columns: table => new
                {
                    HashTagsId = table.Column<int>(type: "int", nullable: false),
                    itemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTagItem", x => new { x.HashTagsId, x.itemsId });
                    table.ForeignKey(
                        name: "FK_HashTagItem_Items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HashTagItem_hashTags_HashTagsId",
                        column: x => x.HashTagsId,
                        principalTable: "hashTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HashTagItem_itemsId",
                table: "HashTagItem",
                column: "itemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionId",
                table: "Items",
                column: "CollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashTagItem");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "hashTags");

            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}
