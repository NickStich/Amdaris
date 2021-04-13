using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignOne
{
    public class WhiteBoardDrawVisitor : IVisitor
    {
        public void Visit(Shape shape)
        {
            if (shape is Circle circle)
            {
                Console.WriteLine($"Drawing circle with radius {circle.Radius} on whiteBoard");
            }

            if (shape is Square square)
            {
                Console.WriteLine($"Drawing circle with radius {square.Length} on whiteBoard");
            }
        }
    }
}
