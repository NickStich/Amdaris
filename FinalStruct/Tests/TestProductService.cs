using Domain;
using Infrastructure.Abstractions.RepositoryAbstractions;
using Infrastructure.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestProductService
    {
        private Mock<IProductRepository> _mockProductRepository;
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [Test]
        public void TestProductNameSameAsFromService()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Name = "IPhone 13",
                    Price = 10000
                },
                new Product
                {
                    Name = "Samsung S12",
                    Price = 8000
                }

            };
            _mockProductRepository.Setup(i => i.GetAllProducts()).Returns(products);

            //Act
            var serviceProducts = _productService.GetAllProducts();

            //Assert
            Assert.AreEqual(products.FirstOrDefault().Name, serviceProducts.FirstOrDefault().Name);
        }

        [TestCase(1, 3, 12)]
        [TestCase(2, 4.2, 16.8)]
        [TestCase(3, 30, 600)]
        [TestCase(4, 15.3, 122.4)]
        [TestCase(5, 13, 169)]
        public void TestProductPriceByGivingQuantityAndValue(int productID, double quantity, double value)
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    Name = "Cui",
                    Price = 4
                },
                new Product
                {
                    Id = 2,
                    Name = "Surub 12x48",
                    Price = 4
                },
                new Product
                {
                    Id = 3,
                    Name = "Sfoara",
                    Price = 20
                },
                new Product
                {
                    Id = 4,
                    Name = "Surubelnita",
                    Price = 8
                },
                new Product
                {
                    Id = 5,
                    Name = "Bec neon",
                    Price = 13
                }

            };
            _mockProductRepository.Setup(i => i.GetAllProducts()).Returns(products);

            //Act
            var serviceProducts = _productService.GetAllProducts();

            //Assert
            Assert.AreEqual(products.Where(p => p.Id == productID).FirstOrDefault().Price, value/quantity);
        }
    }
}
