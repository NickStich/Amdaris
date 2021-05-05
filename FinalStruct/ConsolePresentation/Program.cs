using Application;
using Domain.Invoicing;
using Domain.ThirdParty;
using Domain;
using Infrastructure;
using System;
using System.Linq;
using System.Data.SqlClient;

namespace ConsolePresentation
{
    class Program
    {
        static void Main(string[] args)
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

            //Console.WriteLine("create invoice");
            //Invoice invoice1 = new SalesInvoice { Id = 1, Number = "200101", Date = new DateTime(2020, 01, 01), ThirdParty = newCustomer, Product = new Product { Id = 1, Name = "Surub", Price = 2 }, Quantity = 4 };
            //Invoice invoice2 = new SalesInvoice { Id = 2, Number = "200102", Date = new DateTime(2020, 01, 03), ThirdParty = metro, Product = new Product { Id = 2, Name = "Canapea", Price = 950 }, Quantity = 2 };
            //invoiceRepository.CreateInvoice(invoice1);
            //invoiceRepository.CreateInvoice(invoice2);

            //Console.WriteLine("get all invoices");
            //var invoices = invoiceRepository.GetAllInvoices();
            //Console.WriteLine(string.Join("\n", invoices));

            //Console.WriteLine("update an invoice");
            //var updatedInvoice = new SalesInvoice { Id = 2, Number = "200102", Date = new DateTime(2020, 01, 03), ThirdParty = metro, Product = new Product { Id = 2, Name = "Canapea", Price = 1300 }, Quantity = 2 };
            //invoiceRepository.UpdateInvoice(2, updatedInvoice);
            //var invoicesUpdated = invoiceRepository.GetAllInvoices();
            //Console.WriteLine(string.Join("\n", invoicesUpdated));

            //Console.WriteLine("delete an invoice");
            //invoiceRepository.DeleteInvoice(2);

            //Console.WriteLine("final get all invoices");
            //var finalInvoices = invoiceRepository.GetAllInvoices();
            //Console.WriteLine(string.Join("\n", finalInvoices));

            //var connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestDB;Trusted_Connection=True;User ID=DESKTOP-GB8VVC3\Stich";
            //var connString = @"Server=.\SQLEXPRESS;Database=TestDB;Integrated Security=SSPI;";
            //var connString = @"Data Source=.\SQLEXPRESS;Database=TestDB;Persist Security Info=True;User ID=Stich;Password=4895";
            //var connString = @"Data Source=.\SQLEXPRESS;Database=box;Integrated Security=SSPI";
            var connString = @"Data Source=DESKTOP-GB8VVC3\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True";


            using (var dbContext = new AccountingAppDbContext(connString))
            {
                try
                {
                    var product1 = new Product() { Name = "IPhone", Price = 2500 };
                    var product2 = new Product() { Name = "Samsung", Price = 1500 };

                    dbContext.Products.Add(product1);
                    dbContext.Products.Add(product2);

                    dbContext.SaveChanges();
                    Console.WriteLine("succes");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }

        }
    }
}
