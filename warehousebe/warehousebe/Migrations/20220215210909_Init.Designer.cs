﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using warehousebe.Models;

#nullable disable

namespace warehousebe.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20220215210909_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("warehousebe.model.Cars", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("WarehouseId")
                        .IsUnique();

                    b.ToTable("Car");
                });

            modelBuilder.Entity("warehousebe.model.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lat");

                    b.Property<string>("LocationLong")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("long");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("warehousebe.model.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("Licensed")
                        .HasColumnType("bit")
                        .HasColumnName("licensed");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("make");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("model");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<int>("YearModel")
                        .HasColumnType("int")
                        .HasColumnName("year_model");

                    b.Property<DateTime>("date_added")
                        .HasColumnType("Date");

                    b.HasKey("VehicleId");

                    b.HasIndex("CarId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("warehousebe.model.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("warehousebe.model.Cars", b =>
                {
                    b.HasOne("warehousebe.model.Warehouse", "Warehouse")
                        .WithOne("Cars")
                        .HasForeignKey("warehousebe.model.Cars", "WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("warehousebe.model.Location", b =>
                {
                    b.HasOne("warehousebe.model.Warehouse", "Warehouse")
                        .WithOne("Location")
                        .HasForeignKey("warehousebe.model.Location", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("warehousebe.model.Vehicle", b =>
                {
                    b.HasOne("warehousebe.model.Cars", "Car")
                        .WithMany("Vehicles")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("warehousebe.model.Cars", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("warehousebe.model.Warehouse", b =>
                {
                    b.Navigation("Cars")
                        .IsRequired();

                    b.Navigation("Location")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
