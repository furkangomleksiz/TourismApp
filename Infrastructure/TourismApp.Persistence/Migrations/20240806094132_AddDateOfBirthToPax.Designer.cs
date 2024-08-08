﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TourismApp.Persistence.Data;

#nullable disable

namespace TourismApp.Persistence.Migrations
{
    [DbContext(typeof(TourContext))]
    [Migration("20240806094132_AddDateOfBirthToPax")]
    partial class AddDateOfBirthToPax
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TourismApp.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MainPaxId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TourProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TourProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.Pax", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TCKN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Paxes");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DayNum")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GeneralInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("NightNum")
                        .HasColumnType("integer");

                    b.Property<string>("SlugUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.TourImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("TourImages");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.TourProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("SalesEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("SalesStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TourEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("TourStartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("TourProducts");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.Order", b =>
                {
                    b.HasOne("TourismApp.Domain.Entities.TourProduct", "TourProduct")
                        .WithMany("Orders")
                        .HasForeignKey("TourProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TourProduct");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.Pax", b =>
                {
                    b.HasOne("TourismApp.Domain.Entities.Order", "Order")
                        .WithMany("Paxes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.TourImage", b =>
                {
                    b.HasOne("TourismApp.Domain.Entities.Tour", "Tour")
                        .WithMany("Gallery")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.TourProduct", b =>
                {
                    b.HasOne("TourismApp.Domain.Entities.Tour", "Tour")
                        .WithMany("TourProducts")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.Order", b =>
                {
                    b.Navigation("Paxes");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.Tour", b =>
                {
                    b.Navigation("Gallery");

                    b.Navigation("TourProducts");
                });

            modelBuilder.Entity("TourismApp.Domain.Entities.TourProduct", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
