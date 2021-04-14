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
            _ = shape switch
            {
                Circle c => result = Convert.ToSingle(c.Radius * c.Radius * Math.PI),
                Square s => result = s.Length * s.Length,
                Rectangle r => result = r.Length * r.Width,
                _ => result
            };

            Publish((shape,result));
        }
    }
}
