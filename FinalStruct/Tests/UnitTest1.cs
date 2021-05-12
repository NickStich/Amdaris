using Application;
using Domain;
using Domain.Invoicing;
using Domain.ThirdParty;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private Mock<IInvoiceRepository> _mockInvoiceRepository;
        private InvoiceService _service;

        [SetUp]
        public void Setup()
        {
            _mockInvoiceRepository = new Mock<IInvoiceRepository>();
            _service = new InvoiceService(_mockInvoiceRepository.Object);
        }

        
        [Test]
        public void Test1()
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
            var invs = _service.GetAllInvoices();

            // Assert
            Assert.AreEqual(invs.Count(), invoices.Count);
            Assert.AreEqual(invs.FirstOrDefault().Number, invoices.FirstOrDefault().Number);
        }
    }
}