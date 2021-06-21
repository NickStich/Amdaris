using Domain.ConnectionEntities;
using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoicing
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ThirdPartyPersonId { get; set; }
        public ThirdPartyPerson ThirdPartyPerson { get; set; }
        public virtual InvoiceType Type { get; set; }
        public ICollection<Position> Positions { get; set; }
        public double Value { get; set; }
        public double VATValue { get; set; }
        public virtual VAT VatType { get; set; }
        public InvoiceStatus Status { get; set; }

        public override string ToString()
        {
            return $"Number:{Number} | Date:{Date} ";
        }
    }

    public enum InvoiceType
    {
        Invoice = 0,
        SalesInvoice = 1,
        PurchasesInvoice = 2
    }
}
