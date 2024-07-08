﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.DataAccess.Context;

#nullable disable

namespace TaxCalculator.DataAccess.Migrations
{
    [DbContext(typeof(TaxDbContext))]
    [Migration("20240708090159_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxCalculator.DataAccess.Models.TaxBand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FirstInserted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("LowerLimit")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UpperLimit")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaxBands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41c548b8-b89c-47c7-81cc-4d3373f429d0"),
                            FirstInserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LowerLimit = 0,
                            Rate = 0m,
                            UpperLimit = 5000
                        },
                        new
                        {
                            Id = new Guid("c9608fe8-0580-4afc-803d-f1f7ebbf8192"),
                            FirstInserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LowerLimit = 5000,
                            Rate = 20m,
                            UpperLimit = 20000
                        },
                        new
                        {
                            Id = new Guid("5b5e983b-7981-49c4-a19c-18f162d6fd61"),
                            FirstInserted = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LowerLimit = 20000,
                            Rate = 40m,
                            UpperLimit = 40000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
