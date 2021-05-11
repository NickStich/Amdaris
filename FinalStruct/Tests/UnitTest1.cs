using Domain;
using Domain.ThirdParty;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            //var mockSet = new Mock<DbSet<Product>>();
            //mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}