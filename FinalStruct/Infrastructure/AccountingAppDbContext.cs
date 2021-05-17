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
            .HasDiscriminator<int>("InvoiceType")
            .HasValue<Invoice>(0)
            .HasValue<PurchasesInvoice>(1)
            .HasValue<SalesInvoice>(2);

            modelBuilder.Entity<ThirdPartyPerson>()
            .ToTable("ThirdParties")
            .HasDiscriminator<int>("ThirdPartyPersonType")
            .HasValue<ThirdPartyPerson>(0)
            .HasValue<Supplier>(1)
            .HasValue<Customer>(2);

            modelBuilder.Entity<PositionInvoice>()
                 .HasKey(pi => new { pi.PositionId, pi.InvoiceId });
            modelBuilder.Entity<PositionInvoice>()
                .HasOne(pi => pi.Position)
                .WithMany(pi => pi.Invoices)
                .HasForeignKey(pi => pi.PositionId);
            modelBuilder.Entity<PositionInvoice>()
                .HasOne(pi => pi.Invoice)
                .WithMany(pi => pi.Positions)
                .HasForeignKey(pi => pi.InvoiceId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ThirdPartyPerson> ThirdParties { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionInvoice> PositionInvoices { get; set; }

    }
}
