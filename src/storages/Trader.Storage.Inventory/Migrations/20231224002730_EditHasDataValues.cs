using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trader.Storage.Inventory.Migrations
{
    /// <inheritdoc />
    public partial class EditHasDataValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("5cdfe774-ec24-4d3f-8202-505c4cb8c848"));

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("8691dd34-b741-400a-8aec-4e4d99365953"));

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "resource_name", "title" },
                values: new object[,]
                {
                    { new Guid("49564d6c-88b2-4f65-b6b1-625bb5d30eac"), "www.deribit.com", "deribit.svg", "deribit" },
                    { new Guid("668d2108-372d-467a-bec1-6f0732c5ea5d"), "test.deribit.com", "deribit-test.svg", "test.deribit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("49564d6c-88b2-4f65-b6b1-625bb5d30eac"));

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("668d2108-372d-467a-bec1-6f0732c5ea5d"));

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "resource_name", "title" },
                values: new object[,]
                {
                    { new Guid("5cdfe774-ec24-4d3f-8202-505c4cb8c848"), "www.deribit.com", "deribit", "deribit" },
                    { new Guid("8691dd34-b741-400a-8aec-4e4d99365953"), "test.deribit.com", "deribit-test", "test.deribit" }
                });
        }
    }
}
