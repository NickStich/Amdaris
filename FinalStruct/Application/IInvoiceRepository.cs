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
        void CreateInvoice(Invoice invoice);
        void UpdateInvoice(int invoiceId, Invoice invoice);
        void DeleteInvoice(int invoiceId);
        IEnumerable<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int invoiceId);
        IEnumerable<Invoice> FindInvoicesByThirdPartyId(int ThirdPartyId);
        IEnumerable<Invoice> FindInvoiceByStatus(InvoiceStatus status);
        IEnumerable<Invoice> FindInvoicesByDate(DateTime date);
    }
}
