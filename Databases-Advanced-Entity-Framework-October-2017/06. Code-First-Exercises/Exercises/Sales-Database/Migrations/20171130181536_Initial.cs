namespace P03_SalesDatabase.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Customers",
                table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
            migrationBuilder.CreateTable(
                "Stores",
                table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });
            migrationBuilder.CreateTable(
                "Sales",
                table => new
                {
                    SaleId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        "FK_Sales_Customers_CustomerId",
                        x => x.CustomerId,
                        "Customers",
                        "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Sales_Products_ProductId",
                        x => x.ProductId,
                        "Products",
                        "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Sales_Stores_StoreId",
                        x => x.StoreId,
                        "Stores",
                        "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex("IX_Sales_CustomerId", "Sales", "CustomerId");
            migrationBuilder.CreateIndex("IX_Sales_ProductId", "Sales", "ProductId");
            migrationBuilder.CreateIndex("IX_Sales_StoreId", "Sales", "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Sales");
            migrationBuilder.DropTable("Customers");
            migrationBuilder.DropTable("Products");
            migrationBuilder.DropTable("Stores");
        }
    }
}