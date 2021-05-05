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

namespace Infrastructure
{
    public class AccountingAppDbContext : DbContext
    {
        private readonly string _connString;
        public AccountingAppDbContext(string connString) : base()
        {
            _connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ThirdPartyPerson> ThirdParties { get; set; }

    }
}
