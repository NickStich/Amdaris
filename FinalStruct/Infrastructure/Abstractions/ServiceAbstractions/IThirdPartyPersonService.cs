using Domain.ThirdParty;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.ServiceAbstractions
{
    public interface IThirdPartyPersonService
    {
        void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson);
        void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson);
        void DeleteThirdPartyPerson(int thirdPartyPersonId);
        IEnumerable<ThirdPartyPerson> GetThirdPartyPersons();
        ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId);
        IEnumerable<ThirdPartyPerson> FindPersonByTaxId(string taxId);
        IEnumerable<ThirdPartyPerson> FindPersonByName(string name);
        List<string> GetPersonsType();
    }
}
