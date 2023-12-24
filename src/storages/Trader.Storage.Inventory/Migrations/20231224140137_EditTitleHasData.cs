using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trader.Storage.Inventory.Migrations
{
    /// <inheritdoc />
    public partial class EditTitleHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("4f3534a2-0979-43f9-926b-81fd2275b6bb"), "www.deribit.com", "deribit.svg", "Deribit" },
                    { new Guid("4fcf888a-266a-4bd4-b027-8b6868a8b916"), "test.deribit.com", "deribit-test.svg", "Test Deribit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("4f3534a2-0979-43f9-926b-81fd2275b6bb"));

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("4fcf888a-266a-4bd4-b027-8b6868a8b916"));

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "resource_name", "title" },
                values: new object[,]
                {
                    { new Guid("49564d6c-88b2-4f65-b6b1-625bb5d30eac"), "www.deribit.com", "deribit.svg", "deribit" },
                    { new Guid("668d2108-372d-467a-bec1-6f0732c5ea5d"), "test.deribit.com", "deribit-test.svg", "test.deribit" }
                });
        }
    }
}
