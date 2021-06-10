using Domain.Invoicing;
using Infrastructure.Services.ServiceAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("inv/[action]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
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
        public IActionResult GetById(int id)
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
        public IActionResult Create(Invoice invoice)
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
        public void Delete(int id)
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

        [HttpPut("{id:int}")]
        public void Update(int id, Invoice invoice)
        {
            try
            {
                _invoiceService.UpdateInvoice(id, invoice);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Invoice with ID={id} not found!");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetInvJSON(int id)
        {
            try
            {
                var invoice = _invoiceService.GetCompleteInvoiceById(id);
                return Ok(invoice);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Invoice with ID={id} not found!");
            }
        }
    }
}
