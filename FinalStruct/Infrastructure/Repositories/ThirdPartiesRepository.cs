using Domain.ThirdParty;
using Infrastructure.Abstractions.RepositoryAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ThirdPartiesRepository : IThirdPartyPersonRepository
    {
        private AccountingAppDbContext _dbContext;
        public ThirdPartiesRepository(AccountingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson)
        {
            _dbContext.ThirdParties.Add(thirdPartyPerson);
        }

        public void DeleteThirdPartyPerson(int thirdPartyPersonId)
        {
            _dbContext.ThirdParties.Remove(_dbContext.ThirdParties.Single(i => i.Id == thirdPartyPersonId));
        }
        public ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId)
        {
            return _dbContext.ThirdParties.Find(thirdPartyPersonId);
        }

        public IEnumerable<ThirdPartyPerson> GetThirdPartyPersons()
        {
            return _dbContext.ThirdParties;
        }

        public void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson)
        {
            throw new NotImplementedException();
        }
    }
}
