﻿// <auto-generated />
using System;
using CommonLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommonLayer.Migrations
{
    [DbContext(typeof(ParkingLotDBContext))]
    [Migration("20200529190215_CommonLayerModelParkingLot1")]
    partial class CommonLayerModelParkingLot1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommonLayer.Models.ParkingLotDetails", b =>
                {
                    b.Property<int>("Receipt_Number")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Driver_Name")
                        .IsRequired();

                    b.Property<DateTime>("ParkingDate");

                    b.Property<string>("Parking_Slot")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.Property<string>("Vehicle_Number")
                        .IsRequired();

                    b.Property<string>("Vehicle_Owner_Name")
                        .IsRequired();

                    b.HasKey("Receipt_Number");

                    b.ToTable("ParkingDetail");
                });

            modelBuilder.Entity("CommonLayer.Models.UserRegistration", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("User_Type")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("CommonLayer.Models.VehicleUnPark", b =>
                {
                    b.Property<int>("VehicleUnParkID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Receipt_Number");

                    b.Property<string>("Status");

                    b.Property<double>("TotalTime");

                    b.Property<double>("Total_Amount");

                    b.Property<DateTime>("UnParkDate");

                    b.HasKey("VehicleUnParkID");

                    b.ToTable("VehicleUnPark");
                });
#pragma warning restore 612, 618
        }
    }
}
