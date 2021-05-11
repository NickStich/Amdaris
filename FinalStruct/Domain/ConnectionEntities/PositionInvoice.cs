using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ConnectionEntities
{
    public class PositionInvoice
    {
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
