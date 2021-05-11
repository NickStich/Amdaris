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
        public ICollection<InvoiceThirdParties> ThirdParties { get; set; }
        public ICollection<PositionInvoice> Positions { get; set; }
        public virtual VAT VatType { get; }
        public InvoiceStatus Status { get; set; }

        public override string ToString()
        {
            return $"Number:{Number} |  Date:{Date} | ";
        }


    }
}
