using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IProductService
    {
        ICollection<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int productId);
    }
}
