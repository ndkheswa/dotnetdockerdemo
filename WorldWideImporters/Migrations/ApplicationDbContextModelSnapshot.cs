﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WideWorldImporters.API.Models;

namespace WorldWideImporters.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WideWorldImporters.API.Models.StockItem", b =>
                {
                    b.Property<int?>("StockItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComputedColumnSql("NEXT VALUE FOR [Sequences].[StockItemID]");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ColorID")
                        .HasColumnType("int");

                    b.Property<string>("CustomFields")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsChillerStock")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int?>("LastEditedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("LeadTimeDays")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("MarketingComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OuterPackageID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("QuantityPerOuter")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("RecommendedRetailPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("SearchDetails")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("concat([StockItemName],N' ',[MarketingComments])");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("StockItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SupplierID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("json_query([CustomFields],N'$.Tags')");

                    b.Property<decimal?>("TaxRate")
                        .IsRequired()
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("TypicalWeightPerUnit")
                        .IsRequired()
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int?>("UnitPackageID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("ValidFrom")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValidTo")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("StockItemID");

                    b.ToTable("StockItems","Warehouse");
                });
#pragma warning restore 612, 618
        }
    }
}