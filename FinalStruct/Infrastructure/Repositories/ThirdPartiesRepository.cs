using Domain.ThirdParty;
using Infrastructure.Abstractions.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
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
            _dbContext.SaveChanges();
        }

        public void DeleteThirdPartyPerson(int thirdPartyPersonId)
        {
            _dbContext.ThirdParties.Remove(_dbContext.ThirdParties.Single(i => i.Id == thirdPartyPersonId));
            _dbContext.SaveChanges();
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
            var tppToBeModified =_dbContext.ThirdParties.First(t => t.Id == thirdPartyPersonId);
            if (tppToBeModified != null)
            {
                tppToBeModified.Name = thirdPartyPerson.Name;
                tppToBeModified.TaxId = thirdPartyPerson.TaxId;
                tppToBeModified.Type = thirdPartyPerson.Type;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<ThirdPartyPerson> GetFilteredBy(Func<ThirdPartyPerson, bool> filter)
        {
            return _dbContext.ThirdParties.Where(filter);
        }

        public List<string> GetPersonsType()
        {
            return _dbContext.ThirdParties.Select(t => t.GetType().Name).ToList();
        }
    }
}
