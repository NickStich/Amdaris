using AssignTwo.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo
{
    class AreaCalculatorVisitor : Publisher<(Shape, float)>, IVisitoR
    {
        public void Visit(Shape shape)
        {
            float result = 0;

            switch (shape)
            {
                case Circle c:
                    result = Convert.ToSingle(c.Radius * c.Radius * Math.PI);
                    break;
                case Square s:
                    result = s.Length * s.Length;
                    break;
                case Rectangle r:
                    result = r.Length * r.Width;
                    break;
            }

            Publish((shape,result));
        }
    }
}
