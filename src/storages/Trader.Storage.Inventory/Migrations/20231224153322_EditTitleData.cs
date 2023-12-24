using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trader.Storage.Inventory.Migrations
{
    /// <inheritdoc />
    public partial class EditTitleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("95362ccf-e10d-4519-b0ab-96a40403f182"), "test.deribit.com", "deribit-test.svg", "test-deribit" },
                    { new Guid("978d0c23-e645-4f4c-9f0c-380b09079707"), "www.deribit.com", "deribit.svg", "deribit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("95362ccf-e10d-4519-b0ab-96a40403f182"));

            migrationBuilder.DeleteData(
                table: "exchanges",
                keyColumn: "id",
                keyValue: new Guid("978d0c23-e645-4f4c-9f0c-380b09079707"));

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "resource_name", "title" },
                values: new object[,]
                {
                    { new Guid("4f3534a2-0979-43f9-926b-81fd2275b6bb"), "www.deribit.com", "deribit.svg", "Deribit" },
                    { new Guid("4fcf888a-266a-4bd4-b027-8b6868a8b916"), "test.deribit.com", "deribit-test.svg", "Test Deribit" }
                });
        }
    }
}
