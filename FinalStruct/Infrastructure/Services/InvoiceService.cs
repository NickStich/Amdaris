using Domain.Invoicing;
using DTOs;
using Infrastructure.Abstractions.RepositoryAbstractions;
using Infrastructure.Services.ServiceAbstractions;
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

        public void CreateInvoice(Invoice invoice)
        {
            _invoiceRepository.CreateInvoice(invoice);
        }

        public void DeleteInvoice(int invoiceId)
        {
            _invoiceRepository.DeleteInvoice(invoiceId);
        }

        public IEnumerable<Invoice> FindInvoiceByStatus(InvoiceStatus status)
        {
            return _invoiceRepository.GetFilteredBy(i => i.Status == status);
        }

        public IEnumerable<Invoice> FindInvoicesByDate(DateTime date)
        {
            return _invoiceRepository.GetFilteredBy(i => i.Date == date);
        }

        public IEnumerable<Invoice> FindInvoicesByThirdPartyId(int ThirdPartyId)
        {
           return _invoiceRepository.GetFilteredBy(i => i.ThirdPartyPersonId == ThirdPartyId);
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            var invoices = await _invoiceRepository.GetAllInvoices();
            //var invoiceResult = invoices.Select(i => TransferToDTO(i)).ToList();
            return invoices;
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            //var invoice = _invoiceRepository.GetInvoiceById(invoiceId);
            //return TransferToDTO(invoice);
            return _invoiceRepository.GetInvoiceById(invoiceId);
        }

        public void UpdateInvoice(int invoiceId, Invoice invoice)
        {
            _invoiceRepository.UpdateInvoice(invoiceId, invoice);
        }

        public Invoice GetCompleteInvoiceById(int id)
        {
           return _invoiceRepository.GetCompleteInvoiceById(id);
        }

        private  InvoiceDTO TransferToDTO(Invoice invoice)
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
