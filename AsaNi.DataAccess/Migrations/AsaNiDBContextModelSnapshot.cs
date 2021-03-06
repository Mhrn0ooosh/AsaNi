﻿// <auto-generated />
using System;
using AsaNi.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsaNi.DataAccess.Migrations
{
    [DbContext(typeof(AsaNiDBContext))]
    partial class AsaNiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsaNi.DomainClasses.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNorthern")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "karaj",
                            Area = 0,
                            CreatedBy = "User",
                            CreatedDateTime = new DateTime(2020, 8, 14, 19, 16, 0, 876, DateTimeKind.Local).AddTicks(8894),
                            IsDeleted = false,
                            IsNorthern = false,
                            Name = "Ghasemi",
                            Number = "02102",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "fardis",
                            Area = 0,
                            CreatedBy = "User",
                            CreatedDateTime = new DateTime(2020, 8, 14, 19, 16, 0, 880, DateTimeKind.Local).AddTicks(252),
                            IsDeleted = false,
                            IsNorthern = false,
                            Name = "Diba",
                            Number = "01240",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "mehrshahr",
                            Area = 0,
                            CreatedBy = "User",
                            CreatedDateTime = new DateTime(2020, 8, 14, 19, 16, 0, 880, DateTimeKind.Local).AddTicks(1593),
                            IsDeleted = false,
                            IsNorthern = false,
                            Name = "Baran",
                            Number = "23105",
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("AsaNi.DomainClasses.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Mehrnoosh",
                            LastName = "Developer",
                            PhoneNumber = "09123333342"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ali",
                            LastName = "Developer",
                            PhoneNumber = "09113331355"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Fateme",
                            LastName = "Developer",
                            PhoneNumber = "09125554478"
                        });
                });

            modelBuilder.Entity("AsaNi.DomainClasses.House", b =>
                {
                    b.HasOne("AsaNi.DomainClasses.Owner", "Owner")
                        .WithMany("Houses")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
