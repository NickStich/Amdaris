using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IInvoiceStatus
    {
        public Invoice ChangeStatus(InvoiceStatus invoiceStatus, Invoice invoice);
        public IEnumerable<Invoice> GetAllInvoiceByStatus(InvoiceStatus invoiceStatus);
    }
}
