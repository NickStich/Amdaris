using Domain.Invoicing;
using Infrastructure.Abstractions.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private AccountingAppDbContext _dbContext;

        public InvoiceRepository(AccountingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _dbContext.Invoices.ToListAsync();
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
           return _dbContext.Invoices.Find(invoiceId);
        }

        public void CreateInvoice(Invoice invoice)
        {
            double totalValue = 0;
            foreach (var position in invoice.Positions)
            {
                totalValue += (position.Product.Price * position.Quantity);
            }
            double vatValue = totalValue * 0.19;
            totalValue += vatValue;
            invoice.Value = totalValue;
            invoice.VATValue = vatValue;
            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();
        }

        public void DeleteInvoice(int invoiceId)
        {
            _dbContext.Remove(_dbContext.Invoices.First(i => i.Id == invoiceId));
            _dbContext.SaveChanges();
        }

        public void UpdateInvoice(int invoiceId, Invoice invoice)
        {
            var invoiceToBeModified = _dbContext.Invoices.First(i => i.Id == invoiceId);
            if (invoiceToBeModified != null)
            {
                invoiceToBeModified.Number = invoice.Number;
                invoiceToBeModified.Date = invoice.Date;
                invoiceToBeModified.Status = invoice.Status;
                invoiceToBeModified.ThirdPartyPersonId = invoice.ThirdPartyPersonId;
                invoiceToBeModified.Type = invoice.Type;
                invoiceToBeModified.Positions = invoice.Positions;
                invoiceToBeModified.VatType = invoice.VatType;

                double totalValue = 0;
                foreach (var position in invoice.Positions)
                {
                    totalValue += (position.Product.Price * position.Quantity);
                }
                double vatValue = totalValue * 0.19;
                totalValue += vatValue;

                invoiceToBeModified.Value = totalValue;
                invoiceToBeModified.VATValue = vatValue;

                _dbContext.SaveChanges();
            }
        }
        public IEnumerable<Invoice> GetFilteredBy(Func<Invoice, bool> filter)
        {
            return _dbContext.Invoices.Where(filter);
        }

        public Invoice GetCompleteInvoiceById(int id)
        {
            var invoice = _dbContext.Invoices.Include(i => i.Positions).ThenInclude(p => p.Product).First(i => i.Id == id);
            return invoice;
        }
    }
}
