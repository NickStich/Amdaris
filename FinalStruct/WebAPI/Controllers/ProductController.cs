using Domain;
using Infrastructure.Services.ServiceAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("prod/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
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
                var product = _productService.GetProductById(id);
                return Ok(product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Product with ID={id} not found!");
            }
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                _productService.CreateProduct(product);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Product with ID={product.Id} not added!");
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Product with ID={id} not found!");
            }

        }

        [HttpPut("{id:int}")]
        public void Update(int id, Product product)
        {
            try
            {
                _productService.UpdateProduct(id, product);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Product with ID={id} not found!");
            }
        }
    }
}
