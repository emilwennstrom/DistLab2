﻿// <auto-generated />
using System;
using DistLab2.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DistLab2.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    partial class AuctionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DistLab2.Persistence.AuctionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("StartingPrice")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuctionDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreationDate = new DateTime(2023, 10, 19, 16, 36, 33, 681, DateTimeKind.Local).AddTicks(7545),
                            Description = "Min första auktion",
                            EndDate = new DateTime(2024, 10, 19, 16, 36, 33, 681, DateTimeKind.Local).AddTicks(7579),
                            Name = "Auction1",
                            StartingPrice = 0,
                            Username = "Algot"
                        });
                });

            modelBuilder.Entity("DistLab2.Persistence.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<double>("BidAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfBid")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("BidDbs");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AuctionId = -1,
                            BidAmount = 50.0,
                            DateOfBid = new DateTime(2023, 10, 19, 16, 46, 33, 681, DateTimeKind.Local).AddTicks(7708),
                            Username = "Emil"
                        },
                        new
                        {
                            Id = -2,
                            AuctionId = -1,
                            BidAmount = 58.0,
                            DateOfBid = new DateTime(2023, 10, 19, 16, 56, 33, 681, DateTimeKind.Local).AddTicks(7711),
                            Username = "Albin"
                        });
                });

            modelBuilder.Entity("DistLab2.Persistence.BidDb", b =>
                {
                    b.HasOne("DistLab2.Persistence.AuctionDb", "AuctionDb")
                        .WithMany("Bids")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionDb");
                });

            modelBuilder.Entity("DistLab2.Persistence.AuctionDb", b =>
                {
                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}
