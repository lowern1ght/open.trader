using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trader.Storage.Inventory.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exchanges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    base_url = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    display_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    resource_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exchanges", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "display_name", "name", "resource_name" },
                values: new object[,]
                {
                    { new Guid("26d46a78-2df8-4a6d-82b7-abb985e773fd"), "test.deribit.com", "Test Deribit", "test-deribit", "deribit-test.svg" },
                    { new Guid("c72af506-4876-40cc-8b16-0f5036f70143"), "www.deribit.com", "Deribit", "deribit", "deribit.svg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exchanges");
        }
    }
}
