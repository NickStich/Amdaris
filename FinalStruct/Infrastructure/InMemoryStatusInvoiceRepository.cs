using Application;
using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryStatusInvoiceRepository : IInvoiceStatus
    {
        private List<Invoice> _invoices;
        public Invoice ChangeStatus(InvoiceStatus invoiceStatus, Invoice invoice)
        {
            invoice.Status = invoiceStatus;
            return invoice;
        }

        public IEnumerable<Invoice> GetAllInvoiceByStatus(InvoiceStatus invoiceStatus)
        {
            return _invoices.Where(i => i.Status == invoiceStatus).ToList();
        }
    }
}
