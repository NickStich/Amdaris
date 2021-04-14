using FinalV1.ThirdPartyPersons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1.Invoicing
{
    class SalesInvoice : Invoice
    {
        private VAT _vat;
        public SalesInvoice(int number, DateTime date, ThirdParty supplier, List<Product> products) : base(number, date, supplier, products)
        {
            _vat = VAT.Collected;
        }

        public override string ToString()
        {
            return base.ToString() + $" VAT={_vat}";
        }
    }
}
