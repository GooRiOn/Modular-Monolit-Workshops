﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySpot.Modules.Reservations.Infrastructure.DAL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Migrations
{
    [DbContext(typeof(ReservationsDbContext))]
    [Migration("20220419172750_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("reservations")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int?>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParkingSpotId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<Guid?>("WeeklyReservationsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyReservationsId");

                    b.ToTable("Reservations", "reservations");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "reservations");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("Week")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("_jobTitle")
                        .HasColumnType("text")
                        .HasColumnName("JobTitle");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Week")
                        .IsUnique();

                    b.ToTable("WeeklyReservations", "reservations");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.Reservation", b =>
                {
                    b.HasOne("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", null)
                        .WithMany("Reservations")
                        .HasForeignKey("WeeklyReservationsId");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", b =>
                {
                    b.HasOne("MySpot.Modules.Reservations.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MySpot.Modules.Reservations.Core.Entities.WeeklyReservations", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
