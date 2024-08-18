using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCM.Migrations
{
    /// <inheritdoc />
    public partial class Db4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashTagItem");

            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "hashTags",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => new { x.TagsId, x.itemsId });
                    table.ForeignKey(
                        name: "FK_ItemTag_Items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_hashTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "hashTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ItemId",
                table: "Likes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItemId",
                table: "Comments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_itemsId",
                table: "ItemTag",
                column: "itemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Items_ItemId",
                table: "Likes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Items_ItemId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ItemId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ItemId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "hashTags",
                newName: "Tag");

            migrationBuilder.CreateTable(
                name: "HashTagItem",
                columns: table => new
                {
                    HashTagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
        }
    }
}
