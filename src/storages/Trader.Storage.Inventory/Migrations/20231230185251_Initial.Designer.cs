﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trader.Storage.Inventory;

#nullable disable

namespace Trader.Storage.Inventory.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20231230185251_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trader.Storage.Inventory.Models.Exchange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BaseUrl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("base_url");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("display_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("resource_name");

                    b.HasKey("Id")
                        .HasName("pk_exchanges");

                    b.ToTable("exchanges", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c72af506-4876-40cc-8b16-0f5036f70143"),
                            BaseUrl = "www.deribit.com",
                            DisplayName = "Deribit",
                            Name = "deribit",
                            ResourceName = "deribit.svg"
                        },
                        new
                        {
                            Id = new Guid("26d46a78-2df8-4a6d-82b7-abb985e773fd"),
                            BaseUrl = "test.deribit.com",
                            DisplayName = "Test Deribit",
                            Name = "test-deribit",
                            ResourceName = "deribit-test.svg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}