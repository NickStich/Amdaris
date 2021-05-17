using Domain;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.ServiceAbstractions
{
    public interface IProductService
    {
        public void CreateProduct(Product product);
        public void DeleteProduct(int productId);
        public IEnumerable<Product> FindProductsByName(string name);
        public void UpdateProduct(int productId, Product product);
        ICollection<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int productId);
    }
}
