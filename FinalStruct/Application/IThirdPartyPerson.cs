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
        IEnumerable<ThirdPartyPerson> GetThirdPartyPersons();
        ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId);
        void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson);
        void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson);
        void DeleteThirdPartyPerson(int thirdPartyPersonId);
    }
}
