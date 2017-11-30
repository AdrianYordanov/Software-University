namespace P03_SalesDatabase.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ProductsAddColumnDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Description",
                "Products",
                nullable: true,
                defaultValue: "No description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Description", "Products");
        }
    }
}