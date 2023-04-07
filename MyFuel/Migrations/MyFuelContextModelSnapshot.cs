﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFuel.Data;

#nullable disable

namespace MyFuel.Migrations
{
    [DbContext(typeof(MyFuelContext))]
    partial class MyFuelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyFuel.Models.FuelType", b =>
                {
                    b.Property<int>("Fuel_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Fuel_id"));

                    b.Property<string>("FuelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Fuel_id");

                    b.ToTable("FuelType");
                });

            modelBuilder.Entity("MyFuel.Models.JournalLine", b =>
                {
                    b.Property<int>("Line_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Line_id"));

                    b.Property<int?>("BaleRefill_id")
                        .HasColumnType("int");

                    b.Property<int?>("FuelTypeFuel_id")
                        .HasColumnType("int");

                    b.Property<int?>("Price_id")
                        .HasColumnType("int");

                    b.Property<double>("RefillValue")
                        .HasColumnType("float");

                    b.Property<int>("Refill_id")
                        .HasColumnType("int");

                    b.HasKey("Line_id");

                    b.HasIndex("BaleRefill_id");

                    b.HasIndex("FuelTypeFuel_id");

                    b.HasIndex("Price_id");

                    b.ToTable("JournalLine");
                });

            modelBuilder.Entity("MyFuel.Models.Price", b =>
                {
                    b.Property<int>("Price_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Price_id"));

                    b.Property<int>("Fuel_id")
                        .HasColumnType("int");

                    b.Property<double?>("PriceValue")
                        .HasColumnType("float");

                    b.HasKey("Price_id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("MyFuel.Models.Refill", b =>
                {
                    b.Property<int>("Refill_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Refill_id"));

                    b.Property<int?>("FuelTypeFuel_id")
                        .HasColumnType("int");

                    b.Property<int>("Fuel_id")
                        .HasColumnType("int");

                    b.HasKey("Refill_id");

                    b.HasIndex("FuelTypeFuel_id");

                    b.ToTable("Refill");
                });

            modelBuilder.Entity("MyFuel.Models.JournalLine", b =>
                {
                    b.HasOne("MyFuel.Models.Refill", "Bale")
                        .WithMany()
                        .HasForeignKey("BaleRefill_id");

                    b.HasOne("MyFuel.Models.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeFuel_id");

                    b.HasOne("MyFuel.Models.Price", "Price")
                        .WithMany()
                        .HasForeignKey("Price_id");

                    b.Navigation("Bale");

                    b.Navigation("FuelType");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("MyFuel.Models.Refill", b =>
                {
                    b.HasOne("MyFuel.Models.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeFuel_id");

                    b.Navigation("FuelType");
                });
#pragma warning restore 612, 618
        }
    }
}