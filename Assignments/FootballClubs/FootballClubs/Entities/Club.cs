using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubs.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public string NickName { get; set; }
        public double MarketValue { get; set; }

    }
}
