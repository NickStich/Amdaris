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

        public IEnumerable<Invoice> FindInvoiceByStatus(InvoiceStatus status)
        {
           return _dbContext.Invoices.Where(i => i.Status == status).ToList();
        }

        public IEnumerable<Invoice> FindInvoicesByDate(DateTime date)
        {
            return _dbContext.Invoices.Where(i => i.Date == date).ToList();
        }

        public IEnumerable<Invoice> FindInvoicesByThirdPartyId(int ThirdPartyId)
        {
            //var invoiceList = from invoice in _dbContext.Invoices
            //                  join it in _dbContext.InvoiceThirdParties on invoice.Id equals it.InvoiceId
            //                  join tpp in _dbContext.ThirdParties on it.ThirdPartyPersonId equals tpp.Id
            //                  where tpp.Id == ThirdPartyId
            //                  select invoice;
            //return invoiceList.ToList();
            throw new NotImplementedException();

        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return _dbContext.Invoices.ToList();
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
           return _dbContext.Invoices.Find(invoiceId);
        }

        void IInvoiceRepository.CreateInvoice(Invoice invoice)
        {
            _dbContext.Invoices.Add(invoice);
        }

        void IInvoiceRepository.DeleteInvoice(int invoiceId)
        {
            _dbContext.Remove(_dbContext.Invoices.Single(i => i.Id == invoiceId));
        }

        void IInvoiceRepository.UpdateInvoice(int invoiceId, Invoice invoice)
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
    }
}
