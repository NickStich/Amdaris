using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1.ThirdPartyPersons
{
    public class ThirdParty
    {
        public ThirdParty(int id, string name, string taxIDNumber)
        {
            Id = id;
            Name = name;
            TaxIDNumber = taxIDNumber;
        }

        public int Id { get; }
        public string Name { get; }
        public string TaxIDNumber { get; }

        public override string ToString()
        {
            return $"ID={Id}  Name={Name} TaxID={TaxIDNumber}";
        }
    }
}
