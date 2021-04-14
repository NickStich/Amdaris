using FinalV1.ThirdPartyPersons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1
{
    public class Supplier : ThirdParty
    {
        //private int _id;
        //private string _name;
        //private string _taxIDNumber;

        public Supplier(int id, string name , string taxIDNumber) : base(id, name, taxIDNumber)
        {
        }

        
    }
}
