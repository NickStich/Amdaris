using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoicing
{
    public enum InvoiceStatus
    {
        DRAFT, //The invoice has been created, but it has not been sent to the client.
        SENT, //The invoice has been sent to the client.
        VIEWED, //The invoice has been viewed by the client.
        PAID, //The invoice has been paid in full.
        CANCELED //The invoice has been manually marked as Canceled by the user.
    }
}
