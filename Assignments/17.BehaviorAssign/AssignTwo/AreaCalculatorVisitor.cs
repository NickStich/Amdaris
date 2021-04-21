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
            float result = shape switch
            {
                Circle c =>  Convert.ToSingle(c.Radius * c.Radius * Math.PI),
                Square s =>  s.Length * s.Length,
                Rectangle r =>  r.Length * r.Width,
                _ => 0
            };

            Publish((shape,result));
        }
    }
}
