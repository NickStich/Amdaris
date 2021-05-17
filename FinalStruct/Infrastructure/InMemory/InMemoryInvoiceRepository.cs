//using Application;
using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    /*public class InMemoryInvoiceRepository  : IInvoiceRepository
    {
        private List<Invoice> _invoices;

        public InMemoryInvoiceRepository()
        {
            _invoices = new List<Invoice>();
        }
        public void CreateInvoice(Invoice invoice)
        {
            _invoices.Add(invoice);
        }

        public void DeleteInvoice(int invoiceId)
        {
            var invoice = _invoices.FirstOrDefault(c => c.Id == invoiceId);
            if (invoice == null)
            {
                throw new InvalidOperationException($"Invoice with id {invoiceId} not found");
            }
            _invoices.Remove(invoice);
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _invoices;
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            var invoice = _invoices.FirstOrDefault(c => c.Id == invoiceId);
            if (invoice == null)
            {
                throw new InvalidOperationException($"Invoice with id {invoiceId} not found");
            }
            return invoice;
        }

        public void UpdateInvoice(int invoiceId, Invoice invoice)
        {
            var invoiceToUpdate = _invoices.FirstOrDefault(c => c.Id == invoiceId);
            if (invoiceToUpdate == null)
            {
                throw new InvalidOperationException($"Invoice with id {invoiceId} not found");
            }
            invoiceToUpdate.Number = invoice.Number;
            invoiceToUpdate.Date = invoice.Date;
            //invoiceToUpdate.Products = invoice.Products;
            //invoiceToUpdate.ThirdParty = invoice.ThirdParty;
            //invoiceToUpdate.Quantity = invoice.Quantity;

        }
    }*/
}
