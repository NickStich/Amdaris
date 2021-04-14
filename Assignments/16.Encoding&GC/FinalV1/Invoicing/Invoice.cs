using FinalV1.ThirdPartyPersons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalV1.Invoicing
{
    class Invoice
    {
        private int _number;

        

        private ThirdParty _supplier;
        private List<Product> _products;
        
        public const double VAT_RATE = 0.19;

        public Invoice(int number, DateTime date, ThirdParty supplier, List<Product> products)
        {
            _number = number;
            Date = date;
            _supplier = supplier;
            _products = products;
        }
        public DateTime Date { get; }

        public override string ToString()
        {
            return $"Number={_number} Date={Date} Supplier={_supplier.ToString()} Products={_products.ToString()}";
        }

        public double GetInvoiceTotal()
        {
            var allProductsValues = _products.Sum(p => p.Value);
            return allProductsValues += allProductsValues * VAT_RATE;
        }
    }

    enum VAT
    {
        Collected,
        Deducted,
        ToPay,
        ToReceive
    }
}
