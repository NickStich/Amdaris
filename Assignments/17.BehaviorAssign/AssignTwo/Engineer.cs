using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo.Observer
{
    public class Engineer : ISubscriber<(Shape, float)>
    {
        public Engineer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Notify((Shape, float) item)
        {
            var shape = item.Item1;
            var area = item.Item2;

            switch (shape)
            {
                case Circle circle when area > 30f:
                    Console.WriteLine($"Area of circle with radius {circle.Radius} is too big");
                    break;
                case Square square when area > 20f:
                    Console.WriteLine($"Area of square with length {square.Length} is too big");
                    break;
                default:
                    if (area <= 0)
                    {
                        Console.WriteLine("Impossible area");
                    }
                    else
                    {
                        Console.WriteLine("Seems right");
                    }
                    break;
            }
        }
    }
}
