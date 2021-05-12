using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class InvoiceDTO
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public InvoiceStatus Status { get; set; }

    }
}
