using Domain.ConnectionEntities;
using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ThirdParty
{
    public class ThirdPartyPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public bool IsArchived { get; set; } = false;
        public override string ToString()
        {
            return $"ID:{Id} Name:{Name} with TaxID:{TaxId}";
        }
        public ICollection<Invoice> Invoices { get; set; }
    }

    public enum ThirdPartyType
    {
        Customer,
        Supplier
    }
}
