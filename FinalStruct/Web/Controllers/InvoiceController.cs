using Domain.Invoicing;
using Infrastructure.Services.ServiceAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                var invoices = await _invoiceService.GetAllInvoices();
                return Ok(invoices);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error accesing database");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetInvoiceById(int id)
        {
            try
            {
                var invoice = _invoiceService.GetInvoiceById(id);
                return Ok(invoice);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Invoice with ID={id} not found!");
            }
        }

        [HttpPost]
        public IActionResult CreateInvoice(Invoice invoice)
        {
            try
            {
                if (invoice == null)
                {
                    return BadRequest();
                }
                _invoiceService.CreateInvoice(invoice);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Invoice with ID={invoice.Id} not added!");
            }
        }

        [HttpDelete("{id:int}")]

        public void DeleteInvoice(int id)
        {
            try
            {
                _invoiceService.DeleteInvoice(id);
                Ok();
            }
            catch(Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Invoice with ID={id} not found!");
            }

        }
    }
}
