using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class databaseseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID_OrderDetails",
                keyValue: new Guid("08d37325-65e9-4f9c-b0ab-4e0d55245191"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID_OrderDetails",
                keyValue: new Guid("0a9494a7-7b0d-43c7-aee7-a61d577eb681"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID_OrderDetails",
                keyValue: new Guid("e11268c5-a13f-4355-b93c-fa6707b35d27"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID_Order",
                keyValue: new Guid("b3842250-7332-472a-8200-2de7894e63d8"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID_Order",
                keyValue: new Guid("bae3f662-8925-4019-9c2e-3d8170b1d4b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID_Product",
                keyValue: new Guid("01e5022b-c0fe-4b1c-a344-22cb660597c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID_Product",
                keyValue: new Guid("2ff079c8-0541-486b-a641-c64a0c43d209"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID_Product",
                keyValue: new Guid("b0295cec-c4eb-4f51-b70a-fd74923a4daf"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID_Customer",
                keyValue: new Guid("82698967-3c35-45fe-b5ce-a9b7387c9f85"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID_Customer",
                keyValue: new Guid("8fc9a9ac-afb3-4bf4-a6c2-e7054c5f8b8f"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID_Supplier",
                keyValue: new Guid("c70aaff0-fdec-4722-88de-696db9267875"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID_Supplier",
                keyValue: new Guid("dfbde439-5c39-4b17-ac05-c8df1f50c4a1"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "ID_Warehouse",
                keyValue: new Guid("d582bafc-e6d7-4779-8be2-057df419982a"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "ID_Warehouse",
                keyValue: new Guid("e6128c1c-75cf-43d8-b4a5-fe8fdda4a0d9"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID_Customer", "Address", "CustomerName", "Email", "Phone" },
                values: new object[,]
                {
                    { new Guid("4876cb7e-bd37-4b2c-95cf-f102aaa028fa"), "456 Elm St, Othertown, USA", "Jane Smith", "jane.smith@example.com", "444-555-6666" },
                    { new Guid("a688eb2e-3449-40a0-8368-70f2f10df9a5"), "123 Main St, Anytown, USA", "John Doe", "john.doe@example.com", "111-222-3333" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID_Supplier", "ContactName", "Email", "Phone", "SupplierName" },
                values: new object[,]
                {
                    { new Guid("473a6263-2cdc-455d-a208-1c24e70bf05a"), "Bob", "bob@supplier.com", "098-765-4321", "Supplier B" },
                    { new Guid("919d9944-1777-4d02-96e2-1ef32c5a5785"), "Alice", "alice@supplier.com", "123-456-7890", "Supplier A" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "ID_Warehouse", "Capacity", "Location", "ManagerName", "WarehouseName" },
                values: new object[,]
                {
                    { new Guid("ed4512c6-1b27-4405-803b-3f1757b072ff"), 2000, "Location B", "Manager B", "Warehouse 2" },
                    { new Guid("f9ec72c5-21d5-4293-b15d-877129b54286"), 1000, "Location A", "Manager A", "Warehouse 1" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID_Order", "CustomerID", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("3238d9ce-c058-46ba-8f0b-a6e718531990"), new Guid("4876cb7e-bd37-4b2c-95cf-f102aaa028fa"), new DateTime(2024, 10, 16, 14, 10, 40, 465, DateTimeKind.Utc).AddTicks(7937), "Pending", 30.00m },
                    { new Guid("f02d6dbf-1b4f-4038-bbe0-cef6de394c80"), new Guid("a688eb2e-3449-40a0-8368-70f2f10df9a5"), new DateTime(2024, 10, 16, 14, 10, 40, 465, DateTimeKind.Utc).AddTicks(7932), "Completed", 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID_Product", "ProductName", "QuantityInStock", "SupplierID", "UnitPrice", "WarehouseID" },
                values: new object[,]
                {
                    { new Guid("05d193a3-94e6-4738-892b-1d9a0f8f854c"), "Product 3", 150, new Guid("473a6263-2cdc-455d-a208-1c24e70bf05a"), 20.00m, new Guid("ed4512c6-1b27-4405-803b-3f1757b072ff") },
                    { new Guid("1fc5ee95-0a2b-41c7-91bc-a7856ba767aa"), "Product 2", 200, new Guid("919d9944-1777-4d02-96e2-1ef32c5a5785"), 15.00m, new Guid("f9ec72c5-21d5-4293-b15d-877129b54286") },
                    { new Guid("988d4109-9f96-4adf-a745-15e3d72d9073"), "Product 1", 100, new Guid("919d9944-1777-4d02-96e2-1ef32c5a5785"), 10.00m, new Guid("f9ec72c5-21d5-4293-b15d-877129b54286") }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "ID_OrderDetails", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("50eab1ca-0657-486c-90c3-06dfacef2dd3"), new Guid("3238d9ce-c058-46ba-8f0b-a6e718531990"), new Guid("05d193a3-94e6-4738-892b-1d9a0f8f854c"), 1, 20.00m },
                    { new Guid("6ff466a0-9679-440c-a5cd-89b3ae1b01fa"), new Guid("f02d6dbf-1b4f-4038-bbe0-cef6de394c80"), new Guid("1fc5ee95-0a2b-41c7-91bc-a7856ba767aa"), 1, 15.00m },
                    { new Guid("725bf57a-3563-4234-947a-b0ff8a4f4e81"), new Guid("f02d6dbf-1b4f-4038-bbe0-cef6de394c80"), new Guid("988d4109-9f96-4adf-a745-15e3d72d9073"), 2, 10.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID_OrderDetails",
                keyValue: new Guid("50eab1ca-0657-486c-90c3-06dfacef2dd3"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID_OrderDetails",
                keyValue: new Guid("6ff466a0-9679-440c-a5cd-89b3ae1b01fa"));

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID_OrderDetails",
                keyValue: new Guid("725bf57a-3563-4234-947a-b0ff8a4f4e81"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID_Order",
                keyValue: new Guid("3238d9ce-c058-46ba-8f0b-a6e718531990"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID_Order",
                keyValue: new Guid("f02d6dbf-1b4f-4038-bbe0-cef6de394c80"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID_Product",
                keyValue: new Guid("05d193a3-94e6-4738-892b-1d9a0f8f854c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID_Product",
                keyValue: new Guid("1fc5ee95-0a2b-41c7-91bc-a7856ba767aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID_Product",
                keyValue: new Guid("988d4109-9f96-4adf-a745-15e3d72d9073"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID_Customer",
                keyValue: new Guid("4876cb7e-bd37-4b2c-95cf-f102aaa028fa"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID_Customer",
                keyValue: new Guid("a688eb2e-3449-40a0-8368-70f2f10df9a5"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID_Supplier",
                keyValue: new Guid("473a6263-2cdc-455d-a208-1c24e70bf05a"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID_Supplier",
                keyValue: new Guid("919d9944-1777-4d02-96e2-1ef32c5a5785"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "ID_Warehouse",
                keyValue: new Guid("ed4512c6-1b27-4405-803b-3f1757b072ff"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "ID_Warehouse",
                keyValue: new Guid("f9ec72c5-21d5-4293-b15d-877129b54286"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID_Customer", "Address", "CustomerName", "Email", "Phone" },
                values: new object[,]
                {
                    { new Guid("82698967-3c35-45fe-b5ce-a9b7387c9f85"), "456 Elm St, Othertown, USA", "Jane Smith", "jane.smith@example.com", "444-555-6666" },
                    { new Guid("8fc9a9ac-afb3-4bf4-a6c2-e7054c5f8b8f"), "123 Main St, Anytown, USA", "John Doe", "john.doe@example.com", "111-222-3333" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID_Supplier", "ContactName", "Email", "Phone", "SupplierName" },
                values: new object[,]
                {
                    { new Guid("c70aaff0-fdec-4722-88de-696db9267875"), "Bob", "bob@supplier.com", "098-765-4321", "Supplier B" },
                    { new Guid("dfbde439-5c39-4b17-ac05-c8df1f50c4a1"), "Alice", "alice@supplier.com", "123-456-7890", "Supplier A" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "ID_Warehouse", "Capacity", "Location", "ManagerName", "WarehouseName" },
                values: new object[,]
                {
                    { new Guid("d582bafc-e6d7-4779-8be2-057df419982a"), 2000, "Location B", "Manager B", "Warehouse 2" },
                    { new Guid("e6128c1c-75cf-43d8-b4a5-fe8fdda4a0d9"), 1000, "Location A", "Manager A", "Warehouse 1" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID_Order", "CustomerID", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("b3842250-7332-472a-8200-2de7894e63d8"), new Guid("82698967-3c35-45fe-b5ce-a9b7387c9f85"), new DateTime(2024, 10, 16, 14, 10, 0, 635, DateTimeKind.Utc).AddTicks(9449), "Pending", 30.00m },
                    { new Guid("bae3f662-8925-4019-9c2e-3d8170b1d4b7"), new Guid("8fc9a9ac-afb3-4bf4-a6c2-e7054c5f8b8f"), new DateTime(2024, 10, 16, 14, 10, 0, 635, DateTimeKind.Utc).AddTicks(9443), "Completed", 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID_Product", "ProductName", "QuantityInStock", "SupplierID", "UnitPrice", "WarehouseID" },
                values: new object[,]
                {
                    { new Guid("01e5022b-c0fe-4b1c-a344-22cb660597c9"), "Product 2", 200, new Guid("dfbde439-5c39-4b17-ac05-c8df1f50c4a1"), 15.00m, new Guid("e6128c1c-75cf-43d8-b4a5-fe8fdda4a0d9") },
                    { new Guid("2ff079c8-0541-486b-a641-c64a0c43d209"), "Product 3", 150, new Guid("c70aaff0-fdec-4722-88de-696db9267875"), 20.00m, new Guid("d582bafc-e6d7-4779-8be2-057df419982a") },
                    { new Guid("b0295cec-c4eb-4f51-b70a-fd74923a4daf"), "Product 1", 100, new Guid("dfbde439-5c39-4b17-ac05-c8df1f50c4a1"), 10.00m, new Guid("e6128c1c-75cf-43d8-b4a5-fe8fdda4a0d9") }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "ID_OrderDetails", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("08d37325-65e9-4f9c-b0ab-4e0d55245191"), new Guid("bae3f662-8925-4019-9c2e-3d8170b1d4b7"), new Guid("b0295cec-c4eb-4f51-b70a-fd74923a4daf"), 2, 10.00m },
                    { new Guid("0a9494a7-7b0d-43c7-aee7-a61d577eb681"), new Guid("b3842250-7332-472a-8200-2de7894e63d8"), new Guid("2ff079c8-0541-486b-a641-c64a0c43d209"), 1, 20.00m },
                    { new Guid("e11268c5-a13f-4355-b93c-fa6707b35d27"), new Guid("bae3f662-8925-4019-9c2e-3d8170b1d4b7"), new Guid("01e5022b-c0fe-4b1c-a344-22cb660597c9"), 1, 15.00m }
                });
        }
    }
}
