using System;
using System.Collections.Generic;

namespace AssignOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<IVisitable>
            {
                new Circle(5),
                new Circle(2),
                new Square(12),
                new Circle(13),
                new Square(4),
            };

            IVisitor visitor = new WhiteBoardDrawVisitor();

            try
            {
                shapes.ForEach(shape => shape.Accept(visitor));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
