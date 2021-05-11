using Application;
using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ThirdPartiesRepository : IThirdPartyPerson
    {
        private AccountingAppDbContext _dbContext;
        public void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson)
        {
            _dbContext.ThirdParties.Add(thirdPartyPerson);
        }

        public void DeleteThirdPartyPerson(int thirdPartyPersonId)
        {
            _dbContext.ThirdParties.Remove(_dbContext.ThirdParties.Single(i => i.Id == thirdPartyPersonId));
        }

        public ThirdPartyPerson FindPersonByName(string name)
        {
            return (ThirdPartyPerson)_dbContext.ThirdParties.Where(t => t.Name == name);
        }

        public ThirdPartyPerson FindPersonByTaxId(string taxId)
        {
            return (ThirdPartyPerson)_dbContext.ThirdParties.Where(t => t.TaxId == taxId);
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
