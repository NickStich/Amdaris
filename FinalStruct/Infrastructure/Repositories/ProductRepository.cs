using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AccountingAppDbContext _dbContext;
        public ProductRepository(AccountingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            _dbContext.Remove(_dbContext.Products.Single(p => p.Id == productId));
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products;
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void UpdateProduct(int productId, Product product)
        {
            var productToModify = _dbContext.Products.First(p => p.Id == productId);
            if(productToModify != null)
            {
                productToModify.Name = product.Name;
                productToModify.Price = product.Price;
                _dbContext.SaveChanges();
            }

        }
    }
}
