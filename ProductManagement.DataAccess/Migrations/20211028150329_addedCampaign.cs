using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagement.DataAccess.Migrations
{
    public partial class addedCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    PriceManipulationLimit = table.Column<int>(type: "int", nullable: false),
                    TargetSalesCount = table.Column<int>(type: "int", nullable: false),
                    TotalSales = table.Column<int>(type: "int", nullable: false),
                    TurnOver = table.Column<double>(type: "float", nullable: false),
                    AverageItemPrice = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_CampaignName",
                table: "Campaign",
                column: "CampaignName",
                unique: true,
                filter: "[CampaignName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ProductId",
                table: "Campaign",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
