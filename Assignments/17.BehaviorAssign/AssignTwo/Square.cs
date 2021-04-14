using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo
{
    public class Square : Shape
    {
        public Square(int length)
        {
            Length = length;
        }

        public int Length { get; }

    }
}
