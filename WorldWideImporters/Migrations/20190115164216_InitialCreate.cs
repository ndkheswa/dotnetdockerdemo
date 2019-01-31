using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldWideImporters.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WideWorldImporters");

            migrationBuilder.CreateTable(
                name: "StockItems",
                schema: "WideWorldImporters",
                columns: table => new
                {
                    StockItemID = table.Column<int>(type: "int", nullable: false, computedColumnSql: "NEXT VALUE FOR [Sequences].[StockItemID]"),
                    StockItemName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: true),
                    UnitPackageID = table.Column<int>(type: "int", nullable: false),
                    OuterPackageID = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: false),
                    QuantityPerOuter = table.Column<int>(type: "int", nullable: false),
                    IsChillerStock = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RecommendedRetailPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TypicalWeightPerUnit = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    MarketingComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "json_query([CustomFields],N'$.Tags')"),
                    SearchDetails = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "concat([StockItemName],N' ',[MarketingComments])"),
                    LastEditedBy = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.StockItemID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockItems",
                schema: "WideWorldImporters");
        }
    }
}
