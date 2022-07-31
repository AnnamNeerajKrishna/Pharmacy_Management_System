﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy_Management_System;

namespace Pharmacy_Management_System.Migrations
{
    [DbContext(typeof(PharmacyContextDb))]
    [Migration("20220731165212_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pharmacy_Management_System.Model.Doctor", b =>
                {
                    b.Property<string>("DoctorId")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(225)");

                    b.HasKey("DoctorId");

                    b.ToTable("DoctorsDetails");
                });

            modelBuilder.Entity("Pharmacy_Management_System.Model.Drugs", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<int>("DrugPrice")
                        .HasColumnType("int");

                    b.Property<int>("DrugQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MfdDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("DrugId");

                    b.ToTable("DrugDetails");
                });

            modelBuilder.Entity("Pharmacy_Management_System.Model.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<int>("DrugPrice")
                        .HasColumnType("int");

                    b.Property<int>("DrugQuantity")
                        .HasColumnType("int");

                    b.Property<string>("DrugsName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<bool>("IsPicked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.ToTable("OrdersDetails");
                });

            modelBuilder.Entity("Pharmacy_Management_System.Model.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugAvailable")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("SupplierId");

                    b.ToTable("SupplierDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
