using FootballClubs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs
{
    public class FootballDbContext : DbContext
    {
        private readonly string _connString;
        public FootballDbContext()
        {
            _connString = @"Data Source=DESKTOP-GB8VVC3\SQLEXPRESS;Database=FootballClubs;Integrated Security=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Club> Clubs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<League>().HasData(
                new League
                {
                    Id = 1,
                    Name = "Premier League",
                    FoundationYear = 1992,
                    Country = "England"
                },
                new League
                {
                    Id = 2,
                    Name = "La Liga",
                    FoundationYear = 1983,
                    Country = "Spain"
                },
                new League
                {
                    Id = 3,
                    Name = "Seria A",
                    FoundationYear = 1946,
                    Country = "Italy"
                },
                new League
                {
                    Id = 4,
                    Name = "Bundesliga",
                    FoundationYear = 2000,
                    Country = "Gernamy"
                }
                );

            modelBuilder.Entity<Club>().HasData(
                new Club
                {
                    Id = 1,
                    Name = "FC Liverpool",
                    NickName = "The Reds",
                    LeagueId = 1,
                    MarketValue = 1010000000
                },
                new Club
                {
                    Id = 2,
                    Name = "FC Barcelona",
                    NickName = "Blougrana",
                    LeagueId = 2,
                    MarketValue = 823000000
                },
                new Club
                {
                    Id = 3,
                    Name = "FC Arsenal",
                    NickName = "The Gunners",
                    LeagueId = 1,
                    MarketValue = 549000000
                },
                new Club
                {
                    Id = 4,
                    Name = "FC Manchester City",
                    NickName = "The Citizens",
                    LeagueId = 1,
                    MarketValue = 1030000000
                },
                new Club
                {
                    Id = 5,
                    Name = "FC Valecia",
                    NickName = "The Bats",
                    LeagueId = 2,
                    MarketValue = 270000000
                },
                new Club
                {
                    Id = 6,
                    Name = "Real Madrid",
                    NickName = "Blancos",
                    LeagueId = 2,
                    MarketValue = 745000000
                },
                new Club
                {
                    Id = 7,
                    Name = "FC Juventus",
                    NickName = "The Old Lady",
                    LeagueId = 3,
                    MarketValue = 678000000
                },
                new Club
                {
                    Id = 8,
                    Name = "FC Internazionale Milano",
                    NickName = "Blanco-Nerri",
                    LeagueId = 3,
                    MarketValue = 618000000
                },
                new Club
                {
                    Id = 9,
                    Name = "FC Borrusia Dortmund",
                    NickName = "BVB",
                    LeagueId = 4,
                    MarketValue = 581000000
                },
                new Club
                {
                    Id = 10,
                    Name = "FC Bayern Munich",
                    NickName = "The Bavarians",
                    LeagueId = 4,
                    MarketValue = 841000000
                }
                );
        }
    }
}
