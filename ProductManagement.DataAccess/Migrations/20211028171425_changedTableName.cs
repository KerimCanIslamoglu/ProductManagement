using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagement.DataAccess.Migrations
{
    public partial class changedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Products_ProductId",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_ProductId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Campaign",
                newName: "Campaigns");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ProductId",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_ProductId",
                table: "Campaigns",
                newName: "IX_Campaigns_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaign_CampaignName",
                table: "Campaigns",
                newName: "IX_Campaigns_CampaignName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Products_ProductId",
                table: "Campaigns",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Products_ProductId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Campaigns",
                newName: "Campaign");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Order",
                newName: "IX_Order_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_ProductId",
                table: "Campaign",
                newName: "IX_Campaign_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_CampaignName",
                table: "Campaign",
                newName: "IX_Campaign_CampaignName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaign",
                table: "Campaign",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Products_ProductId",
                table: "Campaign",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
