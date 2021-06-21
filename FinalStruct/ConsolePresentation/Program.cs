using Domain.Invoicing;
using Domain.ThirdParty;
using Domain;
using Infrastructure;
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.ConnectionEntities;
using Infrastructure.Repositories;

namespace ConsolePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new AccountingAppDbContext())
            {
                dbContext.Database.EnsureCreated();

                //var product1 = new Product() { Name = "IPhone 8", Price = 2500 };
                //var product2 = new Product() { Name = "Samsung S10", Price = 1500 };
                //var product3 = new Product() { Name = "Huawei Mate 10", Price = 3000 };
                //var product4 = new Product() { Name = "Nokia 700", Price = 1000 };
                //var product5 = new Product() { Name = "Xiaomi 10", Price = 2700 };
                //dbContext.Products.Add(product1);
                //dbContext.Products.Add(product2);
                //dbContext.Products.Add(product3);
                //dbContext.Products.Add(product4);
                //dbContext.Products.Add(product5);

                var tpp1 = new Customer { Name = "Metro", TaxId = "RO1689221" };
                //var tpp2 = new Supplier { Name = "Auchan", TaxId = "RO9521785" };
                dbContext.ThirdParties.Add(tpp1);
                //dbContext.ThirdParties.Add(tpp2);

                //var inv1 = new Invoice { Number = "2105001", Date = DateTime.Now, ThirdPartyPerson = tpp1, Status = InvoiceStatus.SENT, Type = InvoiceType.SalesInvoice };
                //var inv2 = new Invoice { Number = "2105002", Date = DateTime.Now, ThirdPartyPerson = tpp2, Status = InvoiceStatus.PAID, Type = InvoiceType.PurchasesInvoice };
                //dbContext.Invoices.Add(inv1);
                //dbContext.Invoices.Add(inv2);

                //var position1 = new Position() { Product = product1, Quantity = 8, Invoice = inv1 };
                //var position2 = new Position() { Product = product2, Quantity = 3, Invoice = inv1 };
                //var position3 = new Position() { Product = product5, Quantity = 1, Invoice = inv2 };
                //dbContext.Positions.Add(position1);
                //dbContext.Positions.Add(position2);
                //dbContext.Positions.Add(position3);

                //var posInv1 = new PositionInvoice() { Invoice = inv1, Position = position1 };
                //var posInv2 = new PositionInvoice() { Invoice = inv1, Position = position2 };
                //var posInv3 = new PositionInvoice() { Invoice = inv2, Position = position2 };
                //var posInv4 = new PositionInvoice() { Invoice = inv2, Position = position3 };
                //dbContext.PositionInvoices.Add(posInv1);
                //dbContext.PositionInvoices.Add(posInv2);
                //dbContext.PositionInvoices.Add(posInv3);
                //dbContext.PositionInvoices.Add(posInv4);

                dbContext.SaveChanges();
                Console.WriteLine("succes");

                //var repo = new InvoiceRepository(dbContext);
                //var inv = repo.GetCompleteInvoiceById(113);
                //Console.WriteLine(inv.Number);
                //inv.Positions.ToList().ForEach(p => Console.WriteLine(p.Product.Name+" "+p.Product.Price+" "+p.Id));

            }

        }

        public static void InMemorySeeding()
        {
            //IThirdPartyPerson thirdPartyRepository = new InMemoryThirdPartyPersonRepository();

            //var thirdParties = thirdPartyRepository.GetThirdPartyPersons();
            //Console.WriteLine("get all");
            //var allthirdParty = string.Join("\n", thirdParties);
            //Console.WriteLine(allthirdParty);

            //Console.WriteLine("add");
            //var metro = new Customer { Id = 4, Name = "Metro", TaxId = "RO4373742" };
            //thirdPartyRepository.AddThirdPartyPerson(metro);

            //Console.WriteLine("get by ID");
            //Console.WriteLine(thirdPartyRepository.GetThirdPartyPersonById(2));

            //Console.WriteLine("update");
            //var newCustomer = new Customer { Id = 10, Name = "Hornbach", TaxId = "RO6548166" };
            //thirdPartyRepository.UpdateThirdPartyPerson(2, newCustomer);
            //Console.WriteLine(thirdPartyRepository.GetThirdPartyPersonById(2));

            //Console.WriteLine("delete");
            //thirdPartyRepository.DeleteThirdPartyPerson(2);

            //Console.WriteLine("final get all");
            //var allthirdParty2 = string.Join("\n", thirdParties);
            //Console.WriteLine(allthirdParty2);

            //Console.WriteLine("________________________________________");

            //IInvoiceRepository invoiceRepository = new InMemoryInvoiceRepository();

            ////Console.WriteLine("create invoice");
            ////Invoice invoice1 = new SalesInvoice { Id = 1, Number = "200101", Date = new DateTime(2020, 01, 01), ThirdParty = newCustomer, Product = new Product { Id = 1, Name = "Surub", Price = 2 }, Quantity = 4 };
            ////Invoice invoice2 = new SalesInvoice { Id = 2, Number = "200102", Date = new DateTime(2020, 01, 03), ThirdParty = metro, Product = new Product { Id = 2, Name = "Canapea", Price = 950 }, Quantity = 2 };
            ////invoiceRepository.CreateInvoice(invoice1);
            ////invoiceRepository.CreateInvoice(invoice2);

            //Console.WriteLine("get all invoices");
            //var invoices = invoiceRepository.GetAllInvoices();
            //Console.WriteLine(string.Join("\n", invoices));

            ////Console.WriteLine("update an invoice");
            ////var updatedInvoice = new SalesInvoice { Id = 2, Number = "200102", Date = new DateTime(2020, 01, 03), ThirdParty = metro, Product = new Product { Id = 2, Name = "Canapea", Price = 1300 }, Quantity = 2 };
            ////invoiceRepository.UpdateInvoice(2, updatedInvoice);
            ////var invoicesUpdated = invoiceRepository.GetAllInvoices();
            ////Console.WriteLine(string.Join("\n", invoicesUpdated));

            //Console.WriteLine("delete an invoice");
            //invoiceRepository.DeleteInvoice(2);

            //Console.WriteLine("final get all invoices");
            //var finalInvoices = invoiceRepository.GetAllInvoices();
            //Console.WriteLine(string.Join("\n", finalInvoices));

        }

        public static void  EFCoreTxns()
        {
            /* using (var dbContext = new AccountingAppDbContext())  // 1st Assignment: Database Initialization with dbContext.SaveChanges();
             {
                 dbContext.Database.EnsureCreated();

                 var product1 = new Product() { Name = "IPhone", Price = 2500 };
                 var product2 = new Product() { Name = "Samsung", Price = 1500 };

                 var invoice = new Invoice()
                 {
                     Number = "210501",
                     Date = new DateTime(202, 05, 01),
                    // ThirdParty = metro,
                     Products = new List<Product> { product1, product2 },
                     Status = InvoiceStatus.DRAFT
                 };

                 dbContext.Products.Add(product1);
                 dbContext.Products.Add(product2);
                 dbContext.Invoices.Add(invoice);

                 dbContext.SaveChanges();
                 Console.WriteLine("succes");
             }*/

            /* using (var dbContext = new AccountingAppDbContext())   // 2nd Assignment: Using Transactions in EF
             {
                 using (var dbContextTxn = dbContext.Database.BeginTransaction())
                 {
                     try
                     {
                         dbContext.Database.ExecuteSqlRaw(@"UPDATE Products SET Price = 4000 where Name like '%IPhone%'");
                         var query = dbContext.Products.Where(p => p.Price >= 2500);
                         foreach (var p in query)
                         {
                             p.Name += " Pro";
                         }
                         dbContext.SaveChanges();
                         dbContextTxn.Commit();
                     }
                     catch
                     {
                         dbContextTxn.Rollback();
                     }
                 }
             }*/

            /* using (var dbContext = new AccountingAppDbContext())  // 4th Assignment : N+1 Problem
             {

                 //foreach (var invoice in dbContext.Invoices)  //wrong way
                 //{
                 //    foreach (var product in invoice.Products)
                 //    {
                 //        Console.WriteLine("{0}: {1}", invoice.Number, product.Name);
                 //    }
                 //}

                 foreach (var invoice in dbContext.Invoices.Include("Products"))  // correct way
                 {
                     foreach (var product in invoice.Products)
                     {
                         Console.WriteLine("{0}: {1}", invoice.Number, product.Name);
                     }
                 }
             }*/

            //using (var dbContext = new AccountingAppDbContext())  //5th Assignment : Joins
            //{
            //    IQueryable<Product> outer = dbContext.Products;
            //    IQueryable<ProductInvoice> middle = dbContext.ProductInvoices;
            //    IQueryable<Invoice> inner = dbContext.Invoices;

            //    var productInvoice =  from product in outer
            //                          join pi in middle on product.Id equals pi.ProductId
            //                          join invoice in inner on pi.InvoiceId equals invoice.Id
            //                          select new { Product = product.Name, Invoice = invoice.Number };
            //   Console.WriteLine(productInvoice);
            //}
        }
    }
}
