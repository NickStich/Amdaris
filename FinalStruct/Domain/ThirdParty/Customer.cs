using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ThirdParty
{
    public class Customer : ThirdPartyPerson
    {
        public override ThirdPartyType Type
        {
            get
            {
                return ThirdPartyType.Customer;
            }
        }
        public Customer()
        {
            if (this.Type != ThirdPartyType.Customer)
            {
                throw new InvalidOperationException($"Invalid ThirdPartyType, might be Customer, but is: {this.Type} !");
            }
        }
    }
}
