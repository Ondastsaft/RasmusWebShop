﻿// <auto-generated />
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
    [Migration("20230119195233_FixesinVarukorg")]
    partial class FixesinVarukorg
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefonnummer")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VarukorgId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VarukorgId");

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

                    b.Property<int>("LeverantörsId")
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

                    b.Property<int>("AnvändarId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

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

                    b.Property<int>("VarukorgId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.HasIndex("VarukorgId");

                    b.ToTable("Varukorgsprodukts");
                });

            modelBuilder.Entity("RasmusAB.Models.Användare", b =>
                {
                    b.HasOne("RasmusAB.Models.Varukorg", "Varukorg")
                        .WithMany()
                        .HasForeignKey("VarukorgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Varukorg");
                });

            modelBuilder.Entity("RasmusAB.Models.Order", b =>
                {
                    b.HasOne("RasmusAB.Models.Leverantör", "Leverantör")
                        .WithMany("Orders")
                        .HasForeignKey("LeverantörId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leverantör");
                });

            modelBuilder.Entity("RasmusAB.Models.Produkt", b =>
                {
                    b.HasOne("RasmusAB.Models.Kategori", "Kategori")
                        .WithMany("Produkter")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.HasOne("RasmusAB.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorgsprodukt", b =>
                {
                    b.HasOne("RasmusAB.Models.Produkt", "Produkt")
                        .WithMany("Varukorgsprodukts")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RasmusAB.Models.Varukorg", "Varukorg")
                        .WithMany("Varukorgsprodukts")
                        .HasForeignKey("VarukorgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("Varukorg");
                });

            modelBuilder.Entity("RasmusAB.Models.Kategori", b =>
                {
                    b.Navigation("Produkter");
                });

            modelBuilder.Entity("RasmusAB.Models.Leverantör", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RasmusAB.Models.Produkt", b =>
                {
                    b.Navigation("Varukorgsprodukts");
                });

            modelBuilder.Entity("RasmusAB.Models.Varukorg", b =>
                {
                    b.Navigation("Varukorgsprodukts");
                });
#pragma warning restore 612, 618
        }
    }
}
