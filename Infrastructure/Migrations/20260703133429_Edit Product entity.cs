using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftIQ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditProductentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_inventories_InventoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "products",
                newName: "inventoryID");

            migrationBuilder.RenameIndex(
                name: "IX_products_InventoryId",
                table: "products",
                newName: "IX_products_inventoryID");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryId",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_products_inventories_inventoryID",
                table: "products",
                column: "inventoryID",
                principalTable: "inventories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_inventories_inventoryID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "inventoryID",
                table: "products",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_inventoryID",
                table: "products",
                newName: "IX_products_InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_inventories_InventoryId",
                table: "products",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
