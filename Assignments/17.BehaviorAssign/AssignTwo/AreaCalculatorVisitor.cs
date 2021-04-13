using AssignTwo.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignTwo
{
    class AreaCalculatorVisitor :  Publisher<(Shape, float)>, IVisitoR
    {
        public void Visit(Shape shape)
        {
            var result = shape.GetShapeArea();

            Publish((shape,result));
            
        }
    }
}
