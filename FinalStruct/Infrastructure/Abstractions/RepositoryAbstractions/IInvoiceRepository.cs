using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions.RepositoryAbstractions
{
    public interface IInvoiceRepository
    {
        void CreateInvoice(Invoice invoice);
        void UpdateInvoice(int invoiceId, Invoice invoice);
        void DeleteInvoice(int invoiceId);
        Task<List<Invoice>> GetAllInvoices();
        Invoice GetInvoiceById(int invoiceId);
        IEnumerable<Invoice> GetFilteredBy(Func<Invoice, bool> filter);
        Invoice GetCompleteInvoiceById(int id);
    }
}
