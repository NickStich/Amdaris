using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo
{
    class Rectangle : Shape
    {
        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public int Length { get;  }
        public int Width { get;  }

    }
}
