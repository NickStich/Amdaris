using FootballClubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    public class AdvancedSelectingQueries
    {
        public void FindLeagueWithNumberOfClubsManyThan(int numberOfClubs)
        {
            using (var context = new FootballDbContext())
            {
                var clubsByLeague = context.Clubs
                       .GroupBy(c => c.League.Name)
                       .Select(c => new
                       {
                           Number = c.Key,
                           NumberOfClubs = c.Count()
                       })
                       .Where(c => c.NumberOfClubs > numberOfClubs);
                foreach (var x in clubsByLeague)
                {
                    Console.WriteLine($"{x.Number} with {x.NumberOfClubs} clubs.");
                }
            }
        }

        public void GetLeagueWithClubAndItsNickName()
        {
            using (var context = new FootballDbContext())
            {
                var leagueWithCLubAndNickName = context.Leagues
                    .SelectMany(l => l.Clubs, (l, c) => new
                    {
                        League = l.Name,
                        Country = l.Country,
                        Club = c.Name,
                        NickName = c.NickName
                    });
                foreach (var x in leagueWithCLubAndNickName)
                {
                    Console.WriteLine($"{x.League} from {x.Country} with {x.Club} as {x.NickName}");
                }
            }
        }

        public void GetLeaguesWithAverageClubsValues()
        {
            using (var context = new FootballDbContext())
            {
                var averageClubsValueByLeague = context.Leagues
                    .Select(l => new
                    {
                        League = l.Name,
                        Country = l.Country,
                        Avg = l.Clubs.Average(c => c.MarketValue)
                    });
                foreach (var x in averageClubsValueByLeague)
                {
                    Console.WriteLine($"{x.League} from {x.Country} reached {x.Avg} €");
                }
            }
        }

        public void GetLeaguesWithAtleastOneClubValueGreaterThan(int clubValue)
        {
            using (var context = new FootballDbContext())
            {
                var leagueWithClubsValue = context.Leagues
                    .Where(l => l.Clubs.Any(c => c.MarketValue > clubValue));

                foreach (var x in leagueWithClubsValue)
                {
                    Console.WriteLine($"{x.Name} have atleast one club which value is greater than {clubValue}");
                }
            }
        }

        public void GetLeagueWithClubsValueGreaterThan(int clubValue)
        {
            using (var context = new FootballDbContext())
            {
                var leagueWithClubsValue = context.Leagues
                    .Where(l => l.Clubs.All(c => c.MarketValue > clubValue));

                foreach (var x in leagueWithClubsValue)
                {
                    Console.WriteLine($"{x.Name} have all clubs which club value is greater than {clubValue}");
                }
            }
        }

        public void FindLeagueByAgeCategory()
        {
            using (var context = new FootballDbContext())
            {
                var leagueByAge = context.Leagues
                    .Select(l => new
                    {
                        Name = l.Name,
                        AgeCategory = l.FoundationYear >= 1985 ? "New" : "Old"
                    });
                foreach (var x in leagueByAge)
                {
                    Console.WriteLine($"{x.Name} can be consider a/an {x.AgeCategory} league.");
                }
            }
        }

        public void GetClubNickNameByValueGreaterThan(int clubValue)
        {
            using (var context = new FootballDbContext())
            {
                var clubsNickName = context.Clubs
                    .FromSqlRaw($"SELECT * FROM Clubs WHERE MarketValue > {clubValue}")
                    .Select(c => new
                    {
                        NickName = c.NickName
                    });

                foreach (var x in clubsNickName)
                {
                    Console.WriteLine($"{x.NickName} has market value bigger than {clubValue}.");
                }
            }
        }
    }
}
