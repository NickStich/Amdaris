using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignOne
{
    public class Circle : Shape
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; }
    }
}
