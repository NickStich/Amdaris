﻿// <auto-generated />
using FootballClubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballClubs.Migrations
{
    [DbContext(typeof(FootballDbContext))]
    partial class FootballDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootballClubs.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<double>("MarketValue")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LeagueId = 1,
                            MarketValue = 1010000000.0,
                            Name = "FC Liverpool",
                            NickName = "The Reds"
                        },
                        new
                        {
                            Id = 2,
                            LeagueId = 2,
                            MarketValue = 823000000.0,
                            Name = "FC Barcelona",
                            NickName = "Blougrana"
                        },
                        new
                        {
                            Id = 3,
                            LeagueId = 1,
                            MarketValue = 549000000.0,
                            Name = "FC Arsenal",
                            NickName = "The Gunners"
                        },
                        new
                        {
                            Id = 4,
                            LeagueId = 1,
                            MarketValue = 1030000000.0,
                            Name = "FC Manchester City",
                            NickName = "The Citizens"
                        },
                        new
                        {
                            Id = 5,
                            LeagueId = 2,
                            MarketValue = 270000000.0,
                            Name = "FC Valecia",
                            NickName = "The Bats"
                        },
                        new
                        {
                            Id = 6,
                            LeagueId = 2,
                            MarketValue = 745000000.0,
                            Name = "Real Madrid",
                            NickName = "Blancos"
                        },
                        new
                        {
                            Id = 7,
                            LeagueId = 3,
                            MarketValue = 678000000.0,
                            Name = "FC Juventus",
                            NickName = "The Old Lady"
                        },
                        new
                        {
                            Id = 8,
                            LeagueId = 3,
                            MarketValue = 618000000.0,
                            Name = "FC Internazionale Milano",
                            NickName = "Blanco-Nerri"
                        },
                        new
                        {
                            Id = 9,
                            LeagueId = 4,
                            MarketValue = 581000000.0,
                            Name = "FC Borrusia Dortmund",
                            NickName = "BVB"
                        },
                        new
                        {
                            Id = 10,
                            LeagueId = 4,
                            MarketValue = 841000000.0,
                            Name = "FC Bayern Munich",
                            NickName = "The Bavarians"
                        });
                });

            modelBuilder.Entity("FootballClubs.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoundationYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "England",
                            FoundationYear = 1992,
                            Name = "Premier League"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Spain",
                            FoundationYear = 1983,
                            Name = "La Liga"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Italy",
                            FoundationYear = 1946,
                            Name = "Seria A"
                        },
                        new
                        {
                            Id = 4,
                            Country = "Gernamy",
                            FoundationYear = 2000,
                            Name = "Bundesliga"
                        });
                });

            modelBuilder.Entity("FootballClubs.Entities.Club", b =>
                {
                    b.HasOne("FootballClubs.Entities.League", "League")
                        .WithMany("Clubs")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("FootballClubs.Entities.League", b =>
                {
                    b.Navigation("Clubs");
                });
#pragma warning restore 612, 618
        }
    }
}
