using Application;
using Domain;
using Domain.Invoicing;
using Domain.ThirdParty;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class TestInvoiceService
    {
        private Mock<IInvoiceRepository> _mockInvoiceRepository;
        private InvoiceService _invoiceService;

        [SetUp]
        public void Setup()
        {
            _mockInvoiceRepository = new Mock<IInvoiceRepository>();
            _invoiceService = new InvoiceService(_mockInvoiceRepository.Object);
        }

        
        [Test]
        public void TestInvoiceNumberSameAsFromInvoiceService()
        {
            // Arrange
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Number = "20210511"
                }
            };
            _mockInvoiceRepository.Setup(i => i.GetAllInvoices()).Returns(invoices);

            // Act
            var invs = _invoiceService.GetAllInvoices();

            // Assert
            Assert.AreEqual(invoices.Count, invs.Count());
            Assert.AreEqual(invoices.FirstOrDefault().Number, invs.FirstOrDefault().Number);
        }

        [TestCase(1, 0)]
        public void TestInvoiceFromServiceStatusIndex(int invoiceID, int invoiceStatusIndex)
        {
            // Arrange
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Number = "20210513",
                    Date = new DateTime(2021,05,13),
                    Status = InvoiceStatus.DRAFT
                }
            };
            _mockInvoiceRepository.Setup(i => i.GetInvoiceById(invoiceID)).Returns(invoices.FirstOrDefault());

            // Act
            var invoicesService = _invoiceService.GetInvoiceById(invoiceID);
            var statusIndex = (int)invoicesService.Status;

            // Assert
            Assert.AreEqual(invoiceStatusIndex, statusIndex);
        }
    }
}