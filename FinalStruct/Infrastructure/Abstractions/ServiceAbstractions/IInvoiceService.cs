using Domain.Invoicing;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.ServiceAbstractions
{
    public interface IInvoiceService
    {
        public void CreateInvoice(Invoice invoice);
        public void DeleteInvoice(int invoiceId);
        public IEnumerable<Invoice> FindInvoiceByStatus(InvoiceStatus status);
        public IEnumerable<Invoice> FindInvoicesByDate(DateTime date);
        public IEnumerable<Invoice> FindInvoicesByThirdPartyId(int ThirdPartyId);
        public void UpdateInvoice(int invoiceId, Invoice invoice);
        Task<List<Invoice>> GetAllInvoices();
        Invoice GetInvoiceById(int invoiceId);
        Invoice GetCompleteInvoiceById(int id);
    }
}
