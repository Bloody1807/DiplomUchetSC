using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomUchetSC.Migrations
{
    /// <inheritdoc />
    public partial class tablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Brands_BrandId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeviceTypes_DeviceTypeId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "warehouse");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "DeviceTypes",
                newName: "device_type");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "client");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "brand");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeviceTypeId",
                table: "order",
                newName: "IX_order_DeviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "order",
                newName: "IX_order_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BrandId",
                table: "order",
                newName: "IX_order_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse",
                table: "warehouse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_device_type",
                table: "device_type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_client",
                table: "client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brand",
                table: "brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_brand_BrandId",
                table: "order",
                column: "BrandId",
                principalTable: "brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_client_ClientId",
                table: "order",
                column: "ClientId",
                principalTable: "client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_device_type_DeviceTypeId",
                table: "order",
                column: "DeviceTypeId",
                principalTable: "device_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_brand_BrandId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_client_ClientId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_device_type_DeviceTypeId",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse",
                table: "warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_device_type",
                table: "device_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_client",
                table: "client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brand",
                table: "brand");

            migrationBuilder.RenameTable(
                name: "warehouse",
                newName: "Warehouse");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "device_type",
                newName: "DeviceTypes");

            migrationBuilder.RenameTable(
                name: "client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "brand",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_order_DeviceTypeId",
                table: "Orders",
                newName: "IX_Orders_DeviceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_order_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_order_BrandId",
                table: "Orders",
                newName: "IX_Orders_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Brands_BrandId",
                table: "Orders",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeviceTypes_DeviceTypeId",
                table: "Orders",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
