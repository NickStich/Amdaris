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

        public override float GetShapeArea()
        {
            float area = Convert.ToSingle(Length*Length);

            return area;
        }
    }
}
