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
            switch (shape)
            {
                case Circle c:
                    Console.WriteLine($"Drawing circle with radius {c.Radius} on whiteBoard");
                    break;
                case Square s:
                    Console.WriteLine($"Drawing circle with radius {s.Length} on whiteBoard");
                    break;
            }
        }
    }
}
