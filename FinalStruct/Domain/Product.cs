using Domain.ConnectionEntities;
using Domain.Invoicing;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}
