using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ThirdParty
{
    public class Supplier : ThirdPartyPerson
    {
        public override ThirdPartyType Type
        {
            get
            {
                return ThirdPartyType.Supplier;
            }
        }

        public Supplier()
        {
            if (this.Type != ThirdPartyType.Supplier)
            {
                throw new InvalidOperationException($"Invalid ThirdPartyType, might be Supplier, but is: {this.Type} !");
            }
        }
    }
}
