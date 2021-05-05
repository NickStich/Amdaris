using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoicing
{
    public class SalesInvoice : Invoice
    {

        public override VAT VatType {
            get
            {
                return VAT.Collected;
            }
        }
    }
}
