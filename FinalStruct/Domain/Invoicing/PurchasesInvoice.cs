using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoicing
{
    public class PurchasesInvoice : Invoice
    {
       
        public override VAT VatType
        {
            get
            {
                return VAT.Deducted;
            }
        }
    }
}
