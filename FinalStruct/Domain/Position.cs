using Domain.ConnectionEntities;
using Domain.Invoicing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Position
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double  Quantity { get; set; }
        public double Value
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
        public ICollection<PositionInvoice> Invoices { get; set; }

    }
}
