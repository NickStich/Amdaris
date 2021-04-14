using System;

namespace AssignTwo
{
    public class Shape : IVisitable
    {
        public void Accept(IVisitoR visitor)
        {
            visitor.Visit(this); 
        }
    }
}
