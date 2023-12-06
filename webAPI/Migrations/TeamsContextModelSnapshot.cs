﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webAPI.Contexts;

#nullable disable

namespace webAPI.Migrations
{
    [DbContext(typeof(TeamsContext))]
    partial class TeamsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("webAPI.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = -1,
                            GamesPlayed = 10,
                            Name = "Thibaut tsjienda baloji",
                            Position = "Center",
                            TeamId = 1,
                            TotalPoints = 100
                        },
                        new
                        {
                            PlayerId = -2,
                            GamesPlayed = 10,
                            Name = "Sam Van Rossom",
                            Position = "Guard",
                            TeamId = 1,
                            TotalPoints = 80
                        },
                        new
                        {
                            PlayerId = -3,
                            GamesPlayed = 10,
                            Name = "Andrej Cuyvers",
                            Position = "Forward",
                            TeamId = 2,
                            TotalPoints = 90
                        },
                        new
                        {
                            PlayerId = -4,
                            GamesPlayed = 10,
                            Name = "Godwin thimanga",
                            Position = "Forward",
                            TeamId = 3,
                            TotalPoints = 95
                        });
                });

            modelBuilder.Entity("webAPI.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            Losses = 5,
                            TeamName = "BC Oostende",
                            Wins = 5
                        },
                        new
                        {
                            TeamId = 2,
                            Losses = 2,
                            TeamName = "Kangoeroes Mechelen",
                            Wins = 8
                        },
                        new
                        {
                            TeamId = 3,
                            Losses = 3,
                            TeamName = "Circus Brussel",
                            Wins = 7
                        });
                });

            modelBuilder.Entity("webAPI.Models.Player", b =>
                {
                    b.HasOne("webAPI.Models.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webAPI.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
