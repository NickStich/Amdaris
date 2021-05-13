using Application;
using Domain.Invoicing;
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

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _dbContext.Invoices.ToList();
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
           return _dbContext.Invoices.Find(invoiceId);
        }

        public void CreateInvoice(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
        }

        public void DeleteInvoice(int invoiceId)
        {
            _dbContext.Remove(_dbContext.Invoices.Single(i => i.Id == invoiceId));
        }

        public void UpdateInvoice(int invoiceId, Invoice invoice)
        {
            var invoiceToBeModified = _dbContext.Invoices.First(i => i.Id == invoiceId);
            if (invoiceToBeModified != null)
            {
                invoiceToBeModified.Number = invoice.Number;
                invoiceToBeModified.Date = invoice.Date;
                invoiceToBeModified.Status = invoice.Status;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Invoice> FindInvoicesByThirdPartyId(int ThirdPartyId)
        {
            var invoicesByTPP = from i in _dbContext.Invoices
                                join it in _dbContext.InvoiceThirdParties on i.Id equals it.InvoiceId
                                join t in _dbContext.ThirdParties on it.ThirdPartyPersonId equals t.Id
                                where t.Id == ThirdPartyId
                                select i;
            return invoicesByTPP.ToList();
        }
    }
}
