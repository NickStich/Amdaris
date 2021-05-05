using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoicing
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public virtual ThirdPartyPerson ThirdParty { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Value
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
        public virtual VAT VatType { get; }
        public InvoiceStatus Status { get; set; }

        public override string ToString()
        {
            return $"Number:{Number} |  Date:{Date} |  From/To:{ThirdParty}  | Value:{Value}";
        }

       // public ICollection<Product> Products { get; set; }

      //  public ICollection<ThirdPartyPerson> ThirdParties { get; set; }
    }
}
