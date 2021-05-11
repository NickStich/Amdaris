using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IThirdPartyPerson
    {
        void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson);
        void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson);
        void DeleteThirdPartyPerson(int thirdPartyPersonId);
        IEnumerable<ThirdPartyPerson> GetThirdPartyPersons();
        ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId);
        ThirdPartyPerson FindPersonByTaxId(string taxId);
        ThirdPartyPerson FindPersonByName(string name);

    }
}
