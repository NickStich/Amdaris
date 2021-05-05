using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoicing
{
    public enum VAT
    {
        Collected,
        Deducted,
        ToPay,
        ToReceive
    }
}
