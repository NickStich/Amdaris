using Domain.ThirdParty;
using DTOs;
using Infrastructure.Abstractions.RepositoryAbstractions;
using Infrastructure.Services.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ThirdPartyPersonService : IThirdPartyPersonService
    {
        private readonly IThirdPartyPersonRepository _thirdPartyPersonRepository;

        public ThirdPartyPersonService(IThirdPartyPersonRepository thirdPartyPersonRepository)
        {
            _thirdPartyPersonRepository = thirdPartyPersonRepository;
        }
        public void AddThirdPartyPerson(ThirdPartyPerson thirdPartyPerson)
        {
            _thirdPartyPersonRepository.AddThirdPartyPerson(thirdPartyPerson);
        }

        public void DeleteThirdPartyPerson(int thirdPartyPersonId)
        {
            _thirdPartyPersonRepository.DeleteThirdPartyPerson(thirdPartyPersonId);
        }

        public IEnumerable<ThirdPartyPerson> FindPersonByName(string name)
        {
            return _thirdPartyPersonRepository.GetFilteredBy(t => t.Name == name);
        }

        public IEnumerable<ThirdPartyPerson> FindPersonByTaxId(string taxId)
        {
            return _thirdPartyPersonRepository.GetFilteredBy(t => t.TaxId == taxId);
        }

        public ThirdPartyPerson GetThirdPartyPersonById(int thirdPartyPersonId)
        {
            return _thirdPartyPersonRepository.GetThirdPartyPersonById(thirdPartyPersonId);
        }

        public IEnumerable<ThirdPartyPerson> GetThirdPartyPersons()
        {
            return _thirdPartyPersonRepository.GetThirdPartyPersons();
            //var tppersonsResult = tppersons.Select(i => TransferToDTO(i)).ToList();
            //return tppersonsResult;
        }

        public void UpdateThirdPartyPerson(int thirdPartyPersonId, ThirdPartyPerson thirdPartyPerson)
        {
            _thirdPartyPersonRepository.UpdateThirdPartyPerson(thirdPartyPersonId, thirdPartyPerson);
        }

        public List<string> GetPersonsType()
        {
            return _thirdPartyPersonRepository.GetPersonsType();
        }

        private ThirdPartyPersonDTO TransferToDTO(ThirdPartyPerson tpperson)
        {
            var dto = new ThirdPartyPersonDTO
            {
                Name = tpperson.Name,
                TaxId = tpperson.TaxId
            };
            return dto;
        }
    }
}
