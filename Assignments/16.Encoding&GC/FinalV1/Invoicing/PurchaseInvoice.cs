using FinalV1.ThirdPartyPersons;
using FinalV1.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1
{
    class PurchaseInvoice: Invoice
    {
        private VAT _vat;
        public PurchaseInvoice(int number, DateTime date, ThirdParty supplier, List<Product> products) : base ( number,  date,  supplier, products)
        {
            _vat = VAT.Deducted;
        }

        public override string ToString()
        {
            return base.ToString() + $" VAT={_vat}";
        }

    }


}
