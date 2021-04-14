using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1.ThirdPartyPersons
{
    class Customer : ThirdParty
    {
        public Customer(int id, string name, string taxIDNumber) : base(id, name, taxIDNumber)
        {
        }
    }
}
