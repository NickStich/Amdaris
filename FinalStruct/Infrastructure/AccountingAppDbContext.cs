using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Domain;
using Domain.Invoicing;
using Domain.ThirdParty;
using Domain.ConnectionEntities;

namespace Infrastructure
{
    public class AccountingAppDbContext : DbContext
    {
        private readonly string _connString;
        public AccountingAppDbContext()
        {
            _connString = @"Data Source=DESKTOP-GB8VVC3\SQLEXPRESS;Database=AccApp;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
            .ToTable("Invoices")
            .HasDiscriminator(i => i.Type)
            .HasValue<Invoice>(0)
            .HasValue<SalesInvoice>(InvoiceType.SalesInvoice)
            .HasValue<PurchasesInvoice>(InvoiceType.PurchasesInvoice);
            

            modelBuilder.Entity<ThirdPartyPerson>()
            .ToTable("ThirdParties")
            .HasDiscriminator(t => t.Type)
            .HasValue<ThirdPartyPerson>(ThirdPartyType.ThirdPartyPerson)
            .HasValue<Supplier>(ThirdPartyType.Supplier)
            .HasValue<Customer>(ThirdPartyType.Customer);

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ThirdPartyPerson> ThirdParties { get; set; }
        public DbSet<Position> Positions { get; set; }
        //public DbSet<PositionInvoice> PositionInvoices { get; set; }

    }
}
