﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IInvoiceService
    {
        ICollection<InvoiceDTO> GetAllInvoices();
        InvoiceDTO GetInvoiceById(int invoiceId);
    }
}
