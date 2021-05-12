using Application;
using Domain;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ICollection<ProductDTO> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts().Select(i => TransferToDTO(i)).ToList();
            return products;
        }

        public ProductDTO GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return TransferToDTO(product);
        }

        private ProductDTO TransferToDTO(Product product)
        {
            var dto = new ProductDTO
            {
                Name = product.Name,
                Price = product.Price
            };
            return dto;
        }
    }
}
