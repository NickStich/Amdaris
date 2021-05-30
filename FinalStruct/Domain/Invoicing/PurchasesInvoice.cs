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
        public override InvoiceType Type
        {
            get
            {
                return InvoiceType.PurchasesInvoice;
            }
        }
        public PurchasesInvoice()
        {
            if (this.Type != InvoiceType.PurchasesInvoice)
            {
                throw new InvalidOperationException($"Invalid InvoiceType, might be PurchasesInvoice, but is: {this.Type} !");
            }
        }
        public override VAT VatType
        {
            get
            {
                return VAT.Deducted;
            }
        }
    }
}
