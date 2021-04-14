using AssignTwo.Observer;
using System;
using System.Collections.Generic;

namespace AssignTwo
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
                new Circle(33),
                new Square(0),
                new Rectangle(14,8)
            };

            var visitorPublisher = new AreaCalculatorVisitor();
            var eng = new Engineer("Ion");
            visitorPublisher.AddSubscriber(eng);

            try
            {
                shapes.ForEach(shape => shape.Accept(visitorPublisher));
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }


        }
    }
}
