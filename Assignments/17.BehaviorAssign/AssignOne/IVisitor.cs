using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignOne
{
    public interface IVisitor
    {
        void Visit(Shape shape);
    }
}
