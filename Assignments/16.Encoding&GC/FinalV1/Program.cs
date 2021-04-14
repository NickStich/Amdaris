using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalV1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dedeman = new Supplier(1, "Dedeman", "RO1234567");

            var ceas = new Product(1, "Ceas", 2, 10);
            var surub = new Product(2, "Surub", 200, 10);

            List<Product> cos = new List<Product> { ceas, surub };
            var invoice1 = new PurchaseInvoice(20210406, new DateTime(2021, 04, 06), dedeman, cos);
            var debt = invoice1.GetInvoiceTotal();

            DateTimeOffset dateOfAquisition = invoice1.Date;

            //write in the file
            OrderRecorder.RecordOrderInCart(@"C:\Internship\PROJ\FinalV1\FinalV1\cart.txt", cos.Aggregate(new StringBuilder(),
                (current, next) => current.Append(current.Length == 0 ? "" : "\n").Append(next + " Date of aquisition=" + dateOfAquisition)).ToString());


        }
    }
}
