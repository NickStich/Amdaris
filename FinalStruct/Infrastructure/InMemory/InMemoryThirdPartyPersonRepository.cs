using Application;
using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   /* public class InMemoryThirdPartyPersonRepository : IThirdPartyPerson
    {
        List<ThirdPartyPerson> _thirdParties;
        public InMemoryThirdPartyPersonRepository()
        {
            _thirdParties = new List<ThirdPartyPerson>
            {
                new Customer{Id = 1, Name = "Profi",TaxId = "RO6861321"},
                new Supplier{Id = 2, Name = "Lidl", TaxId = "RO47511581"},
                new Supplier{Id = 3, Name = "Auchan", TaxId = "RO68491222"},
                new Customer{Id = 4, Name = "Mega",TaxId = "RO3689198"}
            };
        }
        public void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson)
        {
            _thirdParties.Add(thirdPartyPerson);
        }

        public void DeleteThirdPartyPerson(int thirdPartyPersonId)
        {
            var tpperson = _thirdParties.FirstOrDefault(c => c.Id == thirdPartyPersonId);
            if (tpperson == null)
            {
                throw new InvalidOperationException($"ThirdPartyPerson with id {thirdPartyPersonId} not found");
            }
            tpperson.IsArchived = true;
        }

        public ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId)
        {
            var tpperson = _thirdParties.FirstOrDefault(c => c.Id == thirdPartyPersonId);
            if (tpperson == null)
            {
                throw new InvalidOperationException($"ThirdPartyPerson with id {thirdPartyPersonId} not found");
            }
            return tpperson;
        }

        public IEnumerable<ThirdPartyPerson> GetThirdPartyPersons()
        {
            return _thirdParties.Where(t => t.IsArchived==false);
        }

        public void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson)
        {
            var tpperson = _thirdParties.FirstOrDefault(c => c.Id == thirdPartyPersonId);
            if (tpperson == null)
            {
                throw new InvalidOperationException($"ThirdPartyPerson with id {thirdPartyPersonId} not found");
            };
            tpperson.Name = thirdPartyPerson.Name;
            tpperson.TaxId = thirdPartyPerson.TaxId;
        }
    }*/
}
