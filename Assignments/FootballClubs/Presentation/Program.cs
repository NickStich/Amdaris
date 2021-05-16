using System;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var asq = new AdvancedSelectingQueries();

            asq.FindLeagueWithNumberOfClubsManyThan(2);

            asq.GetLeagueWithClubAndItsNickName();

            asq.GetLeaguesWithAverageClubsValues();

            asq.GetLeaguesWithAtleastOneClubValueGreaterThan(1000000000);

            asq.GetLeagueWithClubsValueGreaterThan(500000000);

            asq.FindLeagueByAgeCategory();

            asq.GetClubNickNameByValueGreaterThan(800000000);
        }
    }
}
