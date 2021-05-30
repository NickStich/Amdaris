using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions.RepositoryAbstractions
{
    public interface IThirdPartyPersonRepository
    {
        void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson);
        void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson);
        void DeleteThirdPartyPerson(int thirdPartyPersonId);
        IEnumerable<ThirdPartyPerson> GetThirdPartyPersons();
        ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId);
        IEnumerable<ThirdPartyPerson> GetFilteredBy(Func<ThirdPartyPerson, bool> filter);
        List<string> GetPersonsType();
    }
}
