﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OMS74019FINALCSB;

namespace OMS74019FINALCSB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221216072716_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartAmount");

                    b.Property<int>("CartQuantity");

                    b.Property<int>("CustId");

                    b.Property<int>("ProductId");

                    b.HasKey("CartId");

                    b.HasIndex("CustId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustAddress")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(20);

                    b.Property<string>("CustEmail")
                        .IsRequired();

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CustPass")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CustPhone")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(20);

                    b.HasKey("CustId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("TotalPrice");

                    b.Property<int>("UnitPrice");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustId");

                    b.Property<int>("OrderCost");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<int>("OrderQuantity");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("OrderTotal");

                    b.HasKey("OrderId");

                    b.HasIndex("CustId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductCategory")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("ProductCost");

                    b.Property<int>("ProductQuantity");

                    b.Property<string>("ProductUrl");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.TempItems", b =>
                {
                    b.Property<int>("TempProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustId");

                    b.Property<string>("ProductCategory");

                    b.Property<int>("ProductId");

                    b.Property<int>("TotalPrice");

                    b.Property<int>("UnitPrice");

                    b.HasKey("TempProductId");

                    b.HasIndex("CustId");

                    b.HasIndex("ProductId");

                    b.ToTable("TempItems");
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.Cart", b =>
                {
                    b.HasOne("OMS74019FINALCSB.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OMS74019FINALCSB.Data.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.OrderItems", b =>
                {
                    b.HasOne("OMS74019FINALCSB.Data.Models.Orders", "Orders")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OMS74019FINALCSB.Data.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.Orders", b =>
                {
                    b.HasOne("OMS74019FINALCSB.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OMS74019FINALCSB.Data.Models.TempItems", b =>
                {
                    b.HasOne("OMS74019FINALCSB.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OMS74019FINALCSB.Data.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
