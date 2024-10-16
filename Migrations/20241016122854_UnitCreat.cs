using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UnitCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id_Product = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Auto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id_Product);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id_Product", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("84519a35-02b2-49ce-bac6-9119456a08c8"), "холодильник", 100m },
                    { new Guid("d98e7b27-e0b5-4fae-a41e-db3be037c890"), "рыба", 40m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
