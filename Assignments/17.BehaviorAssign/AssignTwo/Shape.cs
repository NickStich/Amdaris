using System;

namespace AssignTwo
{
    public abstract class Shape : IVisitable
    {
        public void Accept(IVisitoR visitor)
        {
            visitor.Visit(this); 
        }

        public abstract float GetShapeArea();
    }
}
