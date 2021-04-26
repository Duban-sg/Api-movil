using Microsoft.EntityFrameworkCore.Migrations;

namespace api_movil.Migrations
{
    public partial class CambiosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesPresentations");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProductPresentations",
                columns: table => new
                {
                    PresentationsPresentationId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPresentations", x => new { x.PresentationsPresentationId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ProductPresentations_Presentations_PresentationsPresentationId",
                        column: x => x.PresentationsPresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPresentations_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPresentations_ProductsProductId",
                table: "ProductPresentations",
                column: "ProductsProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPresentations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "CategoriesPresentations",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    PresentationsPresentationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesPresentations", x => new { x.CategoriesCategoryId, x.PresentationsPresentationId });
                    table.ForeignKey(
                        name: "FK_CategoriesPresentations_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesPresentations_Presentations_PresentationsPresentationId",
                        column: x => x.PresentationsPresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesPresentations_PresentationsPresentationId",
                table: "CategoriesPresentations",
                column: "PresentationsPresentationId");
        }
    }
}
