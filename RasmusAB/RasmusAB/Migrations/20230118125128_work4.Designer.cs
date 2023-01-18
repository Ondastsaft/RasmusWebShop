﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RasmusAB.Models;

#nullable disable

namespace RasmusAB.Migrations
{
    [DbContext(typeof(RasmusABContext))]
    [Migration("20230118125128_work4")]
    partial class work4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RasmusAB.Models.Användare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Land")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefonnummer")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VarukorgsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Användare");
                });

            modelBuilder.Entity("RasmusAB.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorier");
                });

            modelBuilder.Entity("RasmusAB.Models.Leverantör", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Leverantörer");
                });

            modelBuilder.Entity("RasmusAB.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BetalningsUppgifter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeverantörId")
                        .HasColumnType("int");

                    b.Property<double>("Moms")
                        .HasColumnType("float");

                    b.Property<bool>("Slutbetald")
                        .HasColumnType("bit");

                    b.Property<int>("Summa")
                        .HasColumnType("int");

                    b.Property<int>("VarukorgsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeverantörId");

                    b.ToTable("Ordrar");
                });

            modelBuilder.Entity("RasmusAB.Models.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<string>("Färg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.ToTable("Produkter");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AntalProdukter")
                        .HasColumnType("int");

                    b.Property<int?>("AnvändarId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProduktId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnvändarId")
                        .IsUnique()
                        .HasFilter("[AnvändarId] IS NOT NULL");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.HasIndex("ProduktId");

                    b.ToTable("Varukorgar");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorgsprodukt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int?>("VarukorgId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.HasIndex("VarukorgId");

                    b.ToTable("Varukorgsprodukts");
                });

            modelBuilder.Entity("RasmusAB.Models.Order", b =>
                {
                    b.HasOne("RasmusAB.Models.Leverantör", "leverantör")
                        .WithMany()
                        .HasForeignKey("LeverantörId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("leverantör");
                });

            modelBuilder.Entity("RasmusAB.Models.Produkt", b =>
                {
                    b.HasOne("RasmusAB.Models.Kategori", "Kategori")
                        .WithMany("ProduktLista")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.HasOne("RasmusAB.Models.Användare", "Användare")
                        .WithOne("AnvändareVarukorg")
                        .HasForeignKey("RasmusAB.Models.Varukorg", "AnvändarId");

                    b.HasOne("RasmusAB.Models.Order", "Order")
                        .WithOne("Varukorg")
                        .HasForeignKey("RasmusAB.Models.Varukorg", "OrderId");

                    b.HasOne("RasmusAB.Models.Produkt", null)
                        .WithMany("Varukorgs")
                        .HasForeignKey("ProduktId");

                    b.Navigation("Användare");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorgsprodukt", b =>
                {
                    b.HasOne("RasmusAB.Models.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RasmusAB.Models.Varukorg", null)
                        .WithMany("Varukorgsprodukts")
                        .HasForeignKey("VarukorgId");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("RasmusAB.Models.Användare", b =>
                {
                    b.Navigation("AnvändareVarukorg")
                        .IsRequired();
                });

            modelBuilder.Entity("RasmusAB.Models.Kategori", b =>
                {
                    b.Navigation("ProduktLista");
                });

            modelBuilder.Entity("RasmusAB.Models.Order", b =>
                {
                    b.Navigation("Varukorg")
                        .IsRequired();
                });

            modelBuilder.Entity("RasmusAB.Models.Produkt", b =>
                {
                    b.Navigation("Varukorgs");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.Navigation("Varukorgsprodukts");
                });
#pragma warning restore 612, 618
        }
    }
}
