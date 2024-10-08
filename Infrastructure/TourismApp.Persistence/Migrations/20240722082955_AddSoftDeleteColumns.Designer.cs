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
    [Migration("20240722082955_AddSoftDeleteColumns")]
    partial class AddSoftDeleteColumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

            modelBuilder.Entity("TourismApp.Domain.Entities.Tour", b =>
                {
                    b.Navigation("Gallery");

                    b.Navigation("TourProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
