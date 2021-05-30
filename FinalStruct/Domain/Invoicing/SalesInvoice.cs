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
        public override InvoiceType Type
        {
            get
            {
                return InvoiceType.SalesInvoice;
            }
        }
        public SalesInvoice()
        {
            if (this.Type != InvoiceType.SalesInvoice)
            {
                throw new InvalidOperationException($"Invalid InvoiceType, might be SalesInvoice, but is: {this.Type} !");
            }
        }

        public override VAT VatType {
            get
            {
                return VAT.Collected;
            }
        }
    }
}
