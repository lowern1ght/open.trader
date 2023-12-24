using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trader.Storage.Inventory.Migrations
{
    /// <inheritdoc />
    public partial class AddResourceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("05a7296f-15fb-4de0-9592-07b5581e1df3"));

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("6c7fa016-deb4-4901-8e7a-00c46ecc247e"));

            migrationBuilder.AddColumn<string>(
                name: "resource_name",
                table: "exchanges",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "resource_name", "title" },
                values: new object[,]
                {
                    { new Guid("5cdfe774-ec24-4d3f-8202-505c4cb8c848"), "www.deribit.com", "deribit", "deribit" },
                    { new Guid("8691dd34-b741-400a-8aec-4e4d99365953"), "test.deribit.com", "deribit-test", "test.deribit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("5cdfe774-ec24-4d3f-8202-505c4cb8c848"));

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("8691dd34-b741-400a-8aec-4e4d99365953"));

            migrationBuilder.DropColumn(
                name: "resource_name",
                table: "exchanges");

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "title" },
                values: new object[,]
                {
                    { new Guid("05a7296f-15fb-4de0-9592-07b5581e1df3"), "www.deribit.com", "deribit" },
                    { new Guid("6c7fa016-deb4-4901-8e7a-00c46ecc247e"), "test.deribit.com", "test.deribit" }
                });
        }
    }
}
