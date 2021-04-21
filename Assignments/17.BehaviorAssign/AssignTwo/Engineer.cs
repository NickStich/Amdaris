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
            var (shape, area) = item;

            string result = shape switch
            {
                Circle circle when area > 30f =>  $"Area of circle with radius {circle.Radius} is too big",
                Square square when area > 20f =>  $"Area of square with length {square.Length} is too big",
                _ when area <= 0 =>  "Impossible area",
                _ =>  "Seems right"
            };
            Console.WriteLine(result);
        }
    }
}
