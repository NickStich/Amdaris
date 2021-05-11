using Domain.Invoicing;
using Domain.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ConnectionEntities
{
    public class InvoiceThirdParties
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ThirdPartyPersonId { get; set; }
        public ThirdPartyPerson ThirdPartyPerson { get; set; }
    }
}
