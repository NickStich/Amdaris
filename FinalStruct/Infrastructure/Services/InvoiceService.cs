using Application;
using Domain.Invoicing;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public ICollection<InvoiceDTO> GetAllInvoices()
        {
            var invoices = _invoiceRepository.GetAllInvoices().Select(i => TransferToDTO(i) ).ToList();
            return invoices;
        }

        public InvoiceDTO GetInvoiceById(int invoiceId)
        {
            var invoice = _invoiceRepository.GetInvoiceById(invoiceId);
            return TransferToDTO(invoice);
        }

        private InvoiceDTO TransferToDTO(Invoice invoice)
        {
            var dto = new InvoiceDTO
            {
                Number = invoice.Number,
                Date = invoice.Date,
                Status = invoice.Status
            };
            return dto;
        }
    }
}
