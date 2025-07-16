using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ecommerce_products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ecommerce_products",
                newName: "product_name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "ecommerce_products",
                newName: "IX_ecommerce_products_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "product_name",
                table: "ecommerce_products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ecommerce_products",
                table: "ecommerce_products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ecommerce_products_Categories_CategoryId",
                table: "ecommerce_products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ecommerce_products_Categories_CategoryId",
                table: "ecommerce_products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ecommerce_products",
                table: "ecommerce_products");

            migrationBuilder.RenameTable(
                name: "ecommerce_products",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_ecommerce_products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
