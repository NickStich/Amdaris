using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int invoiceId);
        void CreateInvoice(Invoice invoice);
        void UpdateInvoice(int invoiceId, Invoice invoice);
        void DeleteInvoice(int invoiceId);
    }
}
