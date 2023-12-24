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
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    base_url = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exchanges", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "exchanges",
                columns: new[] { "id", "base_url", "title" },
                values: new object[,]
                {
                    { new Guid("05a7296f-15fb-4de0-9592-07b5581e1df3"), "www.deribit.com", "deribit" },
                    { new Guid("6c7fa016-deb4-4901-8e7a-00c46ecc247e"), "test.deribit.com", "test.deribit" }
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
