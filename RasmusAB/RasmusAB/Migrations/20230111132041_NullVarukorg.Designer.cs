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
    [Migration("20230111132041_NullVarukorg")]
    partial class NullVarukorg
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MinVarukorgId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VarukorgsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MinVarukorgId");

                    b.ToTable("Användare");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Användare");
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

            modelBuilder.Entity("RasmusAB.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

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

                    b.Property<int?>("VarukorgId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.HasIndex("VarukorgId");

                    b.ToTable("Produkter");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("KundId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Varukorgar");
                });

            modelBuilder.Entity("RasmusAB.Models.Admin", b =>
                {
                    b.HasBaseType("RasmusAB.Models.Användare");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("RasmusAB.Models.Kund", b =>
                {
                    b.HasBaseType("RasmusAB.Models.Användare");

                    b.HasDiscriminator().HasValue("Kund");
                });

            modelBuilder.Entity("RasmusAB.Models.Användare", b =>
                {
                    b.HasOne("RasmusAB.Models.Varukorg", "MinVarukorg")
                        .WithMany()
                        .HasForeignKey("MinVarukorgId");

                    b.Navigation("MinVarukorg");
                });

            modelBuilder.Entity("RasmusAB.Models.Produkt", b =>
                {
                    b.HasOne("RasmusAB.Models.Kategori", "Kategori")
                        .WithMany("ProduktLista")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RasmusAB.Models.Varukorg", null)
                        .WithMany("VarukorgensProdukter")
                        .HasForeignKey("VarukorgId");

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("RasmusAB.Models.Kategori", b =>
                {
                    b.Navigation("ProduktLista");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.Navigation("VarukorgensProdukter");
                });
#pragma warning restore 612, 618
        }
    }
}
