using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions.RepositoryAbstractions
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void UpdateProduct(int productId, Product product);
        void DeleteProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        IEnumerable<Product> GetFilteredBy(Func<Product, bool> filter);
    }
}
